namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IImageService _imageService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDepartmentService _departmentService;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public DoctorController(IDoctorService doctorService, IPasswordHasher<ApplicationUser> passwordHasher, IImageService imageService, IDepartmentService departmentService,IMapper mapper, IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager)
        {
            _doctorService = doctorService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _imageService = imageService;
            this.mapper = mapper;

            _departmentService = departmentService;
            _passwordHasher = passwordHasher;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<Departments> departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departments.Select(d => new SelectListItem { Value = d.Id, Text = d.DepartmentName });
            Doctor doctor = new Doctor();
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images/Doctors/";

                    doctor.Img = await _imageService.SaveImageAsync(Img, path);
                }
                doctor.UserName = doctor.Email;

                await _doctorService.AddDoctorAsync(doctor);

                return RedirectToAction("Index");
            }
            IEnumerable<Departments> departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departments.Select(d => new SelectListItem { Value = d.Id, Text = d.DepartmentName });
            return View(doctor);

        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            IEnumerable<Departments> departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = departments.Select(d => new SelectListItem { Value = d.Id, Text = d.DepartmentName });
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            var doctorvm = mapper.Map<DoctorVM>(doctor);
            doctorvm.Img = doctor.Img;

            return View(doctorvm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DoctorVM doctorvm, IFormFile? Img)
        {
            if (ModelState.IsValid)
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(doctorvm.Id);
                if (doctor == null)
                {
                    return NotFound();
                }
                mapper.Map(doctorvm, doctor);

                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images/Doctors/";
                    doctor.Img = await _imageService.SaveImageAsync(Img, path);
                }
                else
                {
                    doctor.Img = doctorvm.Img;
                }

                doctor.Gender = doctorvm.Gender;

                IEnumerable<Departments> departments = await _departmentService.GetAllDepartmentsAsync();
                ViewBag.Departments = departments.Select(d => new SelectListItem { Value = d.Id, Text = d.DepartmentName });

                doctor.UserName = doctor.Email;
                doctor.PasswordHash = _passwordHasher.HashPassword(doctor, doctor.PasswordHash);

                await _doctorService.UpdateDoctorAsync(doctor);

                return RedirectToAction("Index");
            }

            return View(doctorvm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }
    }
}
