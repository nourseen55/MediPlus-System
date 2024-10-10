using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
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

        //[AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            Doctor? doctor = _context.Doctors.Include(d => d.Educations).SingleOrDefault(d => d.Id == user.Id);
            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> AddEducation()
        {
            var user = await _userManager.GetUserAsync(User);
            Education education = new Education();
            education.DoctorId = user.Id;
            return View(education);
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(Education educations)
        {
            if(ModelState.IsValid) {
                _context.Educations.Add(educations);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(educations);
        }

        [HttpGet]
        public async Task<IActionResult> EditEducation(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            education.DoctorId = user.Id;

            return View(education);
        }

        [HttpPost]
        public async Task<IActionResult> EditEducation(Education education)
        {
            if (ModelState.IsValid)
            {
                _context.Educations.Update(education);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(education);
        }

    }
}
