#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using HospitalSystem.Core.Enums;
using HospitalSystem.Application.IServices;

namespace Hospital_Management_Project.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IImageService _imageService; 

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IImageService imageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _imageService = imageService; // Assign the injected service
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public List<SelectListItem> GenderList { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "First name is required.")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required.")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Phone(ErrorMessage = "Invalid phone number.")]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Gender is required.")]
            [Display(Name = "Gender")]
            public Gender Gender { get; set; }

            [Required(ErrorMessage = "Date of birth is required.")]
            [Display(Name = "Date of Birth")]
            [DataType(DataType.Date)]
            public DateTime DateOfBirth { get; set; }

            [Display(Name = "Profile Image")]
            public IFormFile Img { get; set; }

            [Display(Name = "Existing Image")]
            public string ExistingImageUrl { get; set; }

            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }

            [Display(Name = "Country")]
            public string Country { get; set; }

            [Display(Name = "City")]
            public string City { get; set; }
        }

        private void LoadGenderList()
        {
            GenderList = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(g => new SelectListItem
                {
                    Value = g.ToString(),
                    Text = g.ToString()
                })
                .ToList();
        }

        private async Task LoadUserDataAsync(ApplicationUser user)
        {
            Username = await _userManager.GetUserNameAsync(user);
            Input = new InputModel
            {
                PhoneNumber = await _userManager.GetPhoneNumberAsync(user),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                ZipCode = user.ZipCode,
                Country = user.Country,
                City = user.City,
                ExistingImageUrl = user.Img 
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            await LoadUserDataAsync(user);
            LoadGenderList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            if (!ModelState.IsValid)
            {
                await LoadUserDataAsync(user);
                LoadGenderList(); 
                return Page();
            }

            await UpdateUserProfileAsync(user);
            return RedirectToPage();
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(User);
        }

        private async Task UpdateUserProfileAsync(ApplicationUser user)
        {
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return;
                }
            }

            // Handle image upload
            if (Input.Img != null && Input.Img.Length > 0)
            {
                // Delete the old image if it exists
                if (!string.IsNullOrEmpty(user.Img))
                {
                    await _imageService.DeleteFileAsync(user.Img);
                }

                // Save the new image
                user.Img = await _imageService.SaveImageAsync(Input.Img, "Images/Patients/");
            }

            // Update user details
            user.FirstName = Input.FirstName;
            user.LastName = Input.LastName;
            user.Gender = Input.Gender;
            user.DateOfBirth = Input.DateOfBirth;
            user.ZipCode = Input.ZipCode;
            user.Country = Input.Country;
            user.City = Input.City;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile information.";
                return;
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
        }
    }
}
