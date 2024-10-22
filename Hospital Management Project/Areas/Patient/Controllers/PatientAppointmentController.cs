namespace Hospital_Management_Project.Areas.Patient.Controllers
{
    [Area("Patient")]
	[Authorize(Roles = nameof(UserRoles.Patient))]
	public class PatientAppointmentController : Controller
	{
		private readonly IAppointmentService _appointmentService;
		private readonly IDoctorService _doctorService;
		private readonly IPatientService _patientService;
		private readonly IDepartmentService _departmentService;
		private readonly IWorkingHourstService _workingHourstService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ApplicationDbContext _context;

		public PatientAppointmentController(
			IAppointmentService appointmentService,
			UserManager<ApplicationUser> userManager,
			IDoctorService doctorService,
			IPatientService patientService,
			ApplicationDbContext context,
			IDepartmentService departmentService,
			IWorkingHourstService workingHourstService)
		{
			_appointmentService = appointmentService;
			_doctorService = doctorService;
			_patientService = patientService;
			_departmentService = departmentService;
			_userManager = userManager;
			_context = context;
			_workingHourstService = workingHourstService;
		}
		public async Task<IActionResult> Index(int? page)
		{
			int pageNum = page ?? 1;
			int pageSize = 4;
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(userId);
			var paginatedAppointments = appointments.ToPagedList(pageNum, pageSize);
			return View(paginatedAppointments);
		}

		[HttpGet]
		public async Task<IActionResult> Create(string? DoctorId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			IEnumerable<Departments> departments =( await _departmentService.GetAllDepartmentsAsync()).ToList();

			string selectedDoctorName = null;
			string selectedDepartmentName = null;
			string selectedDepartmentID = null;

			if (!string.IsNullOrEmpty(DoctorId))
			{
				var doctor = await _doctorService.GetDoctorByIdAsync(DoctorId);
				selectedDoctorName = doctor?.FullName;
				selectedDepartmentID = doctor.DepartmentId;
				selectedDepartmentName = departments.FirstOrDefault(d => d.Id.ToString() == selectedDepartmentID)?.DepartmentName;
				var viewModel2 = new AppoinmentVM
				{
					PatientID = userId,
					Departments = departments.Select(d => new SelectListItem
					{
						Value = d.Id.ToString(),
						Text = d.DepartmentName
					}).Distinct().ToList(),
					SelectedDoctorID = DoctorId,
					SelectedDoctorName = selectedDoctorName,
					SelectedDepartmentID = selectedDepartmentID,
					SelectedDepartmentName = selectedDepartmentName
				};
				return View("newcreate", viewModel2);
			}

			var viewModel = new AppoinmentVM
			{
				PatientID = userId,
				Departments = departments.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.DepartmentName
				}).Distinct().ToList(),
			};

			return View(viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AppoinmentVM model)
		{
			WorkingHours? work = await _workingHourstService.GethoursByIdAsync(model.SelectedWorkingHoursID);
			Departments? dept = await _departmentService.GetDepartmentByIdAsync(model.SelectedDepartmentID);

			if (ModelState.IsValid)
			{
				var appointment = new Appointment
				{
					AppointmentID = Guid.NewGuid().ToString(),
					PatientID = model.PatientID,
					DoctorID = model.SelectedDoctorID,
					DeptId = model.SelectedDepartmentID,
					StartDateTime = work.StartHour,
					EndDateTime = work.EndHour,
					Day = work.Day,
					Department = dept
				};
				work.IsValid = false;
				await _workingHourstService.UpdatehoursAsync(work);
				await _appointmentService.AddAppointmentAsync(appointment);

				return RedirectToAction("Index");
			}
			IEnumerable<Departments> departments = await _departmentService.GetAllDepartmentsAsync();
			model.Departments = departments.Select(d => new SelectListItem
			{
				Value = d.Id.ToString(),
				Text = d.DepartmentName
			}).ToList();
			return View(model);
		}

		[HttpGet]
		public async Task<JsonResult> GetDoctorsByDepartment(string departmentId)
		{
			var doctors = await _doctorService.GetByDepartmentId(departmentId);

			var doctorList = doctors.Select(d => new { value = d.Id, text = d.FullName }).ToList();
			return Json(doctorList);
		}


		[HttpGet]
		public async Task<JsonResult> GetWorkingHoursByDoctor(string doctorId)
		{
			IEnumerable<WorkingHours> workingHours = await _workingHourstService.GetAllWorkingHoursAsync();

			var filteredWorkingHours = workingHours
				.Where(w => w.DoctorId == doctorId && w.IsValid == true)
				.Select(w => new
				{
					value = w.Id.ToString(),
					text = w.Day + ": " + w.StartHour + " - " + w.EndHour
				})
				.ToList();

			if (!filteredWorkingHours.Any())
			{
				Console.WriteLine("No working hours found for this doctor.");
			}

			return Json(filteredWorkingHours);

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ConfirmDelete(string id)
		{
			var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
			var workingHours = await _workingHourstService.GetAllWorkingHoursAsync();
			var filteredWorkingHours = workingHours.FirstOrDefault(a => a.DoctorId == appointment.DoctorID && a.Day == appointment.Day
			&& a.StartHour == appointment.StartDateTime && a.EndHour == appointment.EndDateTime);
			if (filteredWorkingHours != null)
			{
				filteredWorkingHours.IsValid = true;
			}
			await _appointmentService.DeleteAppointmentAsync(id);

			return RedirectToAction("Index");
		}
	}
}
