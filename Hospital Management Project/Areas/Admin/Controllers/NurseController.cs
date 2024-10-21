namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class NurseController : Controller
    {
        private readonly INurseService _nurseService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IDoctorService _DoctorService;
        private readonly IDepartmentService _departmentService;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public NurseController(INurseService nurseService, IPasswordHasher<ApplicationUser> passwordHasher, IMapper mapper, IImageService imageService, IDepartmentService departmentService, IDoctorService doctorService)
        {
            _nurseService = nurseService;
            _mapper = mapper;
            _imageService = imageService;
            _DoctorService = doctorService;
            _departmentService = departmentService;
            _passwordHasher = passwordHasher;
        }
        public async Task<IActionResult> Index()
        {
            var Nurse = await _nurseService.GetAllNursesAsync();
            return View(Nurse);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new NurseVM
            {
                Departmentss = await _departmentService.GetAllDepartmentsAsync(),
                Doctors = await _DoctorService.GetAllDoctorsAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NurseVM model, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images\Nurses";
                    string imgPath = await _imageService.SaveImageAsync(Img, path);
                    model.Img = imgPath;
                }

                Nurse nurse = new()
                {
                    UserName = model.Email
                };
                

                _mapper.Map(model, nurse);

                await _nurseService.AddNurseAsync(nurse);
                return RedirectToAction(nameof(Index));
            }

            model.Departmentss = await _departmentService.GetAllDepartmentsAsync();
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Nurse nurse = await _nurseService.GetNurseByIdAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<NurseVM>(nurse);
            var doctors = await _DoctorService.GetAllDoctorsAsync();
            var dept = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Doctors = doctors.Select(d => new SelectListItem
            {
                Value = d.Id,
                Text = d.FullName
            }).ToList();

            ViewBag.Dept = dept.Select(d => new SelectListItem
            {
                Value = d.Id,
                Text = d.DepartmentName
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NurseVM nurseVM, IFormFile? Img)
        {
            if (ModelState.IsValid)
            {

                var nurse = await _nurseService.GetNurseByIdAsync(nurseVM.ID);
                if (nurse == null)
                {
                    return NotFound();
                }
                 _mapper.Map(nurseVM, nurse);

                if (Img != null && Img.Length > 0)
                {
                    await _imageService.DeleteFileAsync(nurse.Img);
                    var path = @"Images\Nurses";
                    string imgPath = await _imageService.SaveImageAsync(Img, path);
                    nurse.Img = imgPath;
                }
                else
                {
                    nurse.Img=nurseVM.Img;
                }
                nurse.UserName = nurse.Email;
                nurse.PasswordHash = _passwordHasher.HashPassword(nurse, nurse.PasswordHash);
                await _nurseService.UpdateNurseAsync(nurse);

                return RedirectToAction(nameof(Index));
            }
            return View(nurseVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _nurseService.DeleteNurseAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
