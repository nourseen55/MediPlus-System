namespace Hospital_Management_Project.Areas.Patient.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class PatientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;
        private readonly IImageService _imageService;
        public PatientController(IPatientService patientService, IImageService imageService, IMapper mapper)
        {
            _patientService = patientService;
            _imageService = imageService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Patient = await _patientService.GetAllPatientsAsync();
            return View(Patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
