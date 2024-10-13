using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
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
        public async Task<IActionResult> ListOfDoctors(string keyword, int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 6;

            var doctor = await _doctorService.GetAllDoctorsAsync();

            // Convert the keyword to lowercase for case-insensitive searching
            if (!string.IsNullOrEmpty(keyword))
            {
                string lowerCaseKeyword = keyword.ToLower();

                doctor = doctor.Where(d => d.FullName.ToLower().Contains(lowerCaseKeyword) ||
                                           d.Department.DepartmentName.ToLower().Contains(lowerCaseKeyword));
            }
            var doctors = doctor.OrderBy(d => d.FullName).ToPagedList(pageNum, pageSize);

            ViewBag.Keyword = keyword;

            return View(doctors);
        }




        //[AllowAnonymous]
        public async Task<IActionResult> Index(string id)
        {
            Doctor doctor = null;
           
            if (User.IsInRole(UserRoles.Doctor.ToString())){
                var user = await _userManager.GetUserAsync(User);
                doctor = _context.Doctors.Include(d => d.Educations).SingleOrDefault(d => d.Id == user.Id);
            }else if (User.IsInRole(UserRoles.Patient.ToString()))
            {
                doctor = await _doctorService.GetDoctorByIdAsync(id);
            }
            return View(doctor);
        }
        [Authorize(Roles = nameof(UserRoles.Doctor))]
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

        [Authorize(Roles = nameof(UserRoles.Doctor))]
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
