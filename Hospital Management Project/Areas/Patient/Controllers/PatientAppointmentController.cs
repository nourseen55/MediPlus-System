using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using X.PagedList;

namespace Hospital_Management_Project.Areas.Patient.Controllers
{
	[Area("Patient")]
	[Authorize(Roles = nameof(UserRoles.Admin))]
	public class PatientAppointmentController : Controller
	{
		private readonly IAppointmentService _appointmentService;
		private readonly IDoctorService _doctorService;
		private readonly IPatientService _patientService;
		private readonly IDepartmentService _departmentService;
		private readonly ApplicationDbContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public PatientAppointmentController(
			IAppointmentService appointmentService,
			UserManager<ApplicationUser> userManager,
			IDoctorService doctorService,
			IPatientService patientService,
			IDepartmentService departmentService,
			ApplicationDbContext context)
		{
			_appointmentService = appointmentService;
			_doctorService = doctorService;
			_patientService = patientService;
			_departmentService = departmentService;
			_context = context;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index(int? page)
		{
			var appointments = await _appointmentService.GetAllAppointmentsAsync();
			return View(appointments);
		}

		public async Task<IActionResult> IndexToPatient(int? page)
		{
			int pageNum = page ?? 1;
			int pageSize = 4;
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var appointments = await _appointmentService.GetAppointmentsByPatientIdAsync(userId);
			var paginatedAppointments = appointments.ToPagedList(pageNum, pageSize);
			return View(paginatedAppointments);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var viewModel = new AppoinmentVM
			{
				PatientID = userId,
				Departments = _context.Departments.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.DepartmentName
				}).ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AppoinmentVM model)
		{
			if (ModelState.IsValid)
			{
				var appointment = new Appointment
				{
					AppointmentID = Guid.NewGuid().ToString(),
					PatientID = model.PatientID,
					DoctorID = model.SelectedDoctorID,
					DeptId = model.SelectedDepartmentID,
					// Save other appointment data like Date, etc.
				};

				_context.Appointments.Add(appointment);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			// Reload departments if something goes wrong
			model.Departments = _context.Departments.Select(d => new SelectListItem
			{
				Value = d.Id.ToString(),
				Text = d.DepartmentName
			}).ToList();
			return View(model);
		}

		[HttpGet]
		public JsonResult GetDoctorsByDepartment(string departmentId)
		{
			var doctors = _context.Doctors
				.Where(d => d.DepartmentId == departmentId)
				.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.FirstName + " " + d.LastName
				}).ToList();

			return Json(doctors);
		}

		[HttpGet]
		public JsonResult GetWorkingHoursByDoctor(string doctorId)
		{
			var workingHours = _context.WorkingHours
				.Where(wh => wh.DoctorId == doctorId)
				.Select(wh => new SelectListItem
				{
					Value = wh.Id.ToString(),
					Text = $"{wh.Day}: {wh.StartHour} - {wh.EndHour}"
				}).ToList();

			return Json(workingHours);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
			if (appointment == null)
			{
				return NotFound();
			}

			var doctors = await _doctorService.GetAllDoctorsAsync();
			var patients = await _patientService.GetAllPatientsAsync();
			var departments = await _departmentService.GetAllDepartmentsAsync();

			ViewBag.Doctors = doctors.Select(d => new SelectListItem
			{
				Value = d.Id.ToString(),
				Text = d.FullName
			}).ToList();

			ViewBag.Patients = patients.Select(p => new SelectListItem
			{
				Value = p.Id.ToString(),
				Text = p.UserName
			}).ToList();

			ViewBag.Departments = departments.Select(p => new SelectListItem
			{
				Value = p.Id.ToString(),
				Text = p.DepartmentName
			}).ToList();

			ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(Status)));

			return View(appointment);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Appointment appointment)
		{
			if (ModelState.IsValid)
			{
				await _appointmentService.UpdateAppointmentAsync(appointment);
				return RedirectToAction("Index");
			}
			return View(appointment);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ConfirmDelete(string id)
		{
			await _appointmentService.DeleteAppointmentAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> ViewDoctors(string id)
		{
			List<Doctor> doctors = await _doctorService.GetByDepartmentId(id);
			return View(doctors);
		}
	}
}
