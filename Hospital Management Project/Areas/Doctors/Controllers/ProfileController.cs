using HospitalSystem.Application.Services;
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
        private readonly DoctorService _doctorService;
        private readonly ApplicationDbContext _context;

        public ProfileController(UserManager<ApplicationUser> userManager , DoctorService doctorService , ApplicationDbContext context) {
            _userManager = userManager;
            _doctorService = doctorService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> AddEducation()
        {
            var user = await _userManager.GetUserAsync(User);
            Doctor doctor = await _doctorService.GetDoctorByIdAsync(user.Id);
            return View(doctor.Educations);
        }
        //foreach 
        // input item.

        [HttpPost]
        public async Task<IActionResult> AddEducation(IEnumerable<Education> educations)
        {
            var user = await _userManager.GetUserAsync(User);
            Doctor doctor = await _doctorService.GetDoctorByIdAsync(user.Id);
            _context.Educations.AddRange(educations);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Edit , Add Profile
    }
}
