using HospitalSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Doctors
{
    
    public class PatientController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(IAppointmentService appointmentService, UserManager<ApplicationUser> userManager)
        {
            _appointmentService = appointmentService;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            var doctorid = _userManager.GetUserId(User);
            var patients=_appointmentService.GetPatientsByDoctorAsync(doctorid);
            return View(patients);
        }
    }
}
