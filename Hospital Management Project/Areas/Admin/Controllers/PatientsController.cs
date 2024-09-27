using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Hospital_Management_Project.Areas.Patient.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PatientController(IPatientService patientService, IWebHostEnvironment webHostEnvironment)
        {
            _patientService = patientService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var Patient = await _patientService.GetAllPatientsAsync();
            return View(Patient);
        }
        public async Task<IActionResult> Details(string id)
        {
            var Patient = await _patientService.GetPatientByIdAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }
            return View(Patient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var patient = new HospitalSystem.Core.Entities.Patient();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HospitalSystem.Core.Entities.Patient patient, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                string RootPath = _webHostEnvironment.WebRootPath;

                if (Img != null && Img.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString();

                    var filePath = Path.Combine(RootPath, @"Images\Patients");
                    var extension = Path.GetExtension(Img.FileName);

                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName + extension), FileMode.Create))
                    {
                        await Img.CopyToAsync(fileStream);
                    }

                    patient.Img = @"Images\Patients\" + fileName + extension;
                }
                await _patientService.AddPatientAsync(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var Patient = await _patientService.GetPatientByIdAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }
            return View(Patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HospitalSystem.Core.Entities.Patient patient,IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                string RootPath = _webHostEnvironment.WebRootPath;

                if (Img != null && Img.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString();

                    var filePath = Path.Combine(RootPath, @"Images\Patients");
                    var extension = Path.GetExtension(Img.FileName);

                    using (var fileStream = new FileStream(Path.Combine(filePath, fileName + extension), FileMode.Create))
                    {
                        await Img.CopyToAsync(fileStream);
                    }

                    patient.Img = @"Images\Patients\" + fileName + extension;
                }
                await _patientService.UpdatePatientAsync(patient);
                
                return RedirectToAction(nameof(Index));
            }
            return View(patient);

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
