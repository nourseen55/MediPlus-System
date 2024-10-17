using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;


namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class AppointmentController : Controller
    {
       private readonly IAppointmentService _IAppointmentService;
        private readonly IDoctorService _IDoctorService;
        private readonly IPatientService _IPatientService;
        private readonly IDepartmentService _departmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AppointmentController(IAppointmentService IAppointmentService, UserManager<ApplicationUser> userManager,IDoctorService IDoctorService, IPatientService IPatientService, IDepartmentService departmentService)
        {
            _IAppointmentService = IAppointmentService;
            _IDoctorService = IDoctorService;
            _IPatientService = IPatientService;
            _departmentService = departmentService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var app= await _IAppointmentService.GetAllAppointmentsAsync();
            return View(app);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await _IAppointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction("Index");
        }
		
	}
}
