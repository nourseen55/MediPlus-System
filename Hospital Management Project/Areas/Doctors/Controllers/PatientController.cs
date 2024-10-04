using HospitalSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    public class PatientController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientService _patientService;
        public PatientController(IAppointmentService appointmentService, IPatientService patientService,UserManager<ApplicationUser> userManager)
        {
            _appointmentService = appointmentService;
            _userManager = userManager;
            _patientService = patientService;
        }

        public async Task< IActionResult> Index()
        {
            var doctorid = _userManager.GetUserId(User);
            var patients = await _appointmentService.GetPatientsByDoctorAsync(doctorid);
            return View(patients);
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
