using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    [Authorize(Roles = nameof(UserRoles.Doctor))]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var Doctor = await _userManager.GetUserAsync(User);
            return View(Doctor);
        }
        //Edit , Add Profile
    }
}
