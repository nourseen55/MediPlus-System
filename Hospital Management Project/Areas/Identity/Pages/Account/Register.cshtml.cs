using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HospitalSystem.Application.IServices;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital_Management_Project.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IImageService _imageService; // Image service for handling images

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IImageService imageService) // Inject IImageService
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _imageService = imageService; // Initialize IImageService
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public List<SelectListItem> GenderList => Enum.GetValues(typeof(Gender))
            .Cast<Gender>()
            .Select(g => new SelectListItem
            {
                Value = g.ToString(),
                Text = g.ToString()
            })
            .ToList();

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required]
            [Display(Name = "Date of Birth")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [Required]
            [Display(Name = "Profile Image")]
            public IFormFile Img { get; set; }

            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Display(Name = "Country")]
            public string Country { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public IActionResult OnPostExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var patient = new HospitalSystem.Core.Entities.Patient
                {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Gender = Input.Gender,
                    DateOfBirth = Input.DateOfBirth,
                    ZipCode = Input.ZipCode,
                    Country = Input.Country,
                    City = Input.City,
                    UserName = Input.Email,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                };

                // Handle image upload
                if (Input.Img != null && Input.Img.Length > 0)
                {
                    var path = @"Images/Patients/";
                    patient.Img = await _imageService.SaveImageAsync(Input.Img, path);
                }

                var result = await _userManager.CreateAsync(patient, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(patient, UserRoles.Patient.ToString());

                    // Generate email confirmation token
                    var userId = await _userManager.GetUserIdAsync(patient);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(patient);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    // Use the generated email body
                    var emailBody = GenerateEmailBody(callbackUrl, Input.Email);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email", emailBody);

                    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

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
    }
}
