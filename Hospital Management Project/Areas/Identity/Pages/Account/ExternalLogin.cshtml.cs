// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.ViewModels;

namespace Hospital_Management_Project.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ProviderDisplayName { get; set; }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public IActionResult OnGet() => RedirectToPage("./Login");

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);
            var existingUser = await _userManager.FindByEmailAsync(userEmail);

            if (existingUser != null)
            {
                 await _signInManager.SignInAsync(existingUser, isPersistent: false);
                 return LocalRedirect(returnUrl);
            }

            ReturnUrl = returnUrl;
            ProviderDisplayName = info.ProviderDisplayName;

            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                Input = new InputModel
                {
                    Email = userEmail
                };
            }
            return Page();
        }


        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            var userEmail = info.Principal.FindFirstValue(ClaimTypes.Email);

            var existingUser = await _userManager.FindByEmailAsync(userEmail);

            if (existingUser != null)
            {
                var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

                if (result.Succeeded)
                {
                    _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                    return LocalRedirect(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "External login failed. Please try again.");
                    return Page();
                }
            }

            if (ModelState.IsValid)
            {
                //var user = CreateUser();

                //var claims = info.Principal.Claims;
                //foreach (var claim in claims)
                //{
                //    _logger.LogInformation($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                //}

                string Name = info.Principal.FindFirstValue(ClaimTypes.Name);
                var FullName = Name.Split(' ');

                var patient = new HospitalSystem.Core.Entities.Patient
                {
                    FirstName = FullName[0],
                    LastName = FullName[1],
                    UserName = userEmail,
                    Email = userEmail
                };

                await _userStore.SetUserNameAsync(patient, userEmail, CancellationToken.None);
                await _emailStore.SetEmailAsync(patient, userEmail, CancellationToken.None);

                var result = await _userManager.CreateAsync(patient, Input.Password);

                await _userManager.AddToRoleAsync(patient, UserRoles.Patient.ToString());
                
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(patient, info);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                        #region Email Confirmation

                        var userId = await _userManager.GetUserIdAsync(patient);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(patient);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        var emailBody = GenerateEmailBody(callbackUrl, userEmail);

                        await _emailSender.SendEmailAsync(userEmail, "Confirm your email", emailBody);
                        #endregion

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("./RegisterConfirmation", new { Email = userEmail, returnUrl });
                        }

                        await _signInManager.SignInAsync(patient, isPersistent: false, info.LoginProvider);
                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ProviderDisplayName = info.ProviderDisplayName;
            ReturnUrl = returnUrl;
            return Page();
        }

        #region Email Body
        private string GenerateEmailBody(string callbackUrl, string email)
        {
            return $@"
    <!DOCTYPE html>
    <html>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <style>
            body {{
                font-family: Arial, sans-serif;
                background-color: #f4f4f7;
                color: #333333;
                margin: 0;
                padding: 0;
            }}
            .container {{
                width: 100%;
                max-width: 600px;
                margin: 0 auto;
                padding: 20px;
                background-color: #ffffff;
                border-radius: 8px;
                box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            }}
            .header {{
                text-align: center;
                padding: 20px 0;
            }}
            .header img {{
                width: 100px;
                margin-bottom: 20px;
            }}
            .content {{
                padding: 20px;
            }}
            .content h1 {{
                color: #111111;
                font-size: 24px;
                margin-bottom: 20px;
            }}
            .content p {{
                font-size: 16px;
                line-height: 1.6;
                margin-bottom: 20px;
            }}
            .btn {{
                display: inline-block;
                padding: 12px 25px;
                color: #ffffff;
                background-color: #007bff;
                border-radius: 5px;
                text-decoration: none;
                font-size: 16px;
            }}
            .btn:hover {{
                background-color: #0056b3;
            }}
            .footer {{
                text-align: center;
                padding: 20px 0;
                font-size: 14px;
                color: #888888;
            }}
        </style>
    </head>
    <body>
        <div class='container'>
            <img src='https://th.bing.com/th/id/OIP.byIdD-ZjaQ9DaGLcIR0OuwAAAA?rs=1&pid=ImgDetMain' width='100' alt='Logo' />
            <div class='content'>
                <h1>Confirm your email</h1>
                <p>Thank you for registering with us! Please confirm your email by clicking the button below:</p>
                <a href='{HtmlEncoder.Default.Encode(callbackUrl)}' class='btn'>Confirm Email</a>
                <p>If you did not create an account, no further action is required.</p>
            </div>
            <div class='footer'>
                <p>&copy; {DateTime.UtcNow.Year} Your Company. All rights reserved.</p>
            </div>
        </div>
    </body>
    </html>";
        }
        #endregion

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
