using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using X.PagedList;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDoctorService _doctorService;
        private readonly IEducationService _educationService;
        private readonly ApplicationDbContext _context; 
            
            

        public ProfileController(UserManager<ApplicationUser> userManager , IEducationService educationService,IDoctorService doctorService , ApplicationDbContext context) {
            _userManager = userManager;
            _doctorService = doctorService;
            _context = context;
            _doctorService= doctorService;
            _educationService = educationService;
        }
        public async Task<IActionResult> ListOfDoctors(string keyword, int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 6;

            var doctor = await _doctorService.GetAllDoctorsAsync();

            if (!string.IsNullOrEmpty(keyword))
            {
                string lowerCaseKeyword = keyword.ToLower();
                doctor = doctor.Where(d => d.FullName.ToLower().StartsWith(lowerCaseKeyword) ||
                                           d.Department.DepartmentName.ToLower().StartsWith(lowerCaseKeyword));
            }

            var doctors = doctor.OrderBy(d => d.FullName).ToPagedList(pageNum, pageSize);

            ViewBag.Keyword = keyword;

            return View(doctors);
        }


        public async Task<IActionResult> Index(string id)
        {
            Doctor doctor = null;
            if (User.IsInRole(UserRoles.Doctor.ToString())){
                var user = await _userManager.GetUserAsync(User);
                doctor = await _doctorService.GetDoctorByIdAsync (user.Id);
            }
            else
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
               await _educationService.AddEducationAsync(educations);
                return RedirectToAction("Index");
            }

           return View(educations);
        }

        [Authorize(Roles = nameof(UserRoles.Doctor))]
        [HttpGet]
        public async Task<IActionResult> EditEducation(string id)
        {
            var education = await _educationService.GetEducationIdAsync(id);
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
                await _educationService.UpdateEducationAsync(education);
                return RedirectToAction("Index");
            }
            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(string id)
        {
           await _educationService.DeleteEducationAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
