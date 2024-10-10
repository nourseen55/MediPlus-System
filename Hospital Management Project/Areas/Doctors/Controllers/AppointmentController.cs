using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
	[Area("Doctors")]
	[Authorize(Roles = nameof(UserRoles.Doctor))]

	public class AppointmentController : Controller
	{
		private readonly IAppointmentService _appointmentService;
		private readonly UserManager<ApplicationUser> _userManager;

		public AppointmentController(IAppointmentService appointmentService, UserManager<ApplicationUser> userManager)
		{
            _appointmentService = appointmentService;
			_userManager = userManager;
        }

        public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			var doctorId = user.Id;

			var patients = await _appointmentService.GetPatientsByDoctorAsync(doctorId);
			return View(patients);
		}
	}
}
