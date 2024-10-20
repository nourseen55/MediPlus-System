namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
	[Authorize(Roles = "Doctor,Nurse")]

	public class AppointmentController : Controller
	{
		private readonly IAppointmentService _appointmentService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly INurseService _inurseService;
		public AppointmentController(IAppointmentService appointmentService, INurseService nurseService,UserManager<ApplicationUser> userManager)
		{
            _appointmentService = appointmentService;
			_userManager = userManager;
			_inurseService = nurseService;
        }

        public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			string doctorId = null;

			if (User.IsInRole("Doctor"))
			{
				doctorId = user.Id;

			}
			else if (User.IsInRole("Nurse"))
			{
				Nurse nurse = await _inurseService.GetNurseByIdAsync(user.Id);
				doctorId = nurse.DoctorID;
			}

			var patients = await _appointmentService.GetPatientsByDoctorAsync(doctorId);
			return View(patients);
		}
	}
}
