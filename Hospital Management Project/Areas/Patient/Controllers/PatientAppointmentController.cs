using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

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
		public async Task< IActionResult> Create()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			IEnumerable<Departments> departments =await _departmentService.GetAllDepartmentsAsync();
			List<Departments> departments1= departments.ToList();
			
			var viewModel = new AppoinmentVM
			{
				PatientID = userId,
				Departments = departments1.Select(d => new SelectListItem
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
				await _appointmentService.AddAppointmentAsync(appointment);
				await _workingHourstService.DeletehoursAsync(model.SelectedWorkingHoursID);

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
        public async Task<JsonResult >GetDoctorsByDepartment(string departmentId)
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
                .Where(w => w.DoctorId == doctorId)
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
