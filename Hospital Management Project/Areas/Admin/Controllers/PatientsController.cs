using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;

namespace Hospital_Management_Project.Areas.Patient.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        public async Task<IActionResult> Index()
        {
            var Patient = await _patientService.GetAllPatientsAsync();
            return View(Patient);
        }
        public async Task<IActionResult> Details(int id)
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
        public async Task<IActionResult> Create(HospitalSystem.Core.Entities.Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _patientService.AddPatientAsync(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(int? id, HospitalSystem.Core.Entities.Patient patient)
        {
            if (id.ToString() != patient.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _patientService.UpdatePatientAsync(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var Patient = await _patientService.GetPatientByIdAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }
            return View(Patient);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
