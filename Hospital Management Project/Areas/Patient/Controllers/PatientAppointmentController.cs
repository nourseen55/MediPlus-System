using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList;


namespace Hospital_Management_Project.Areas.Patient.Controllers
{
    [Area("Patient")]
    [Authorize(Roles = nameof(UserRoles.Patient))]
    public class AppointmentController : Controller
    {
       private readonly IAppointmentService _IAppointmentService;
        private readonly IDoctorService _IDoctorService;
        private readonly IPatientService _IPatientService;
        private readonly IDepartmentService _departmentService;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public AppointmentController(IAppointmentService IAppointmentService, UserManager<ApplicationUser> userManager,IDoctorService IDoctorService, IPatientService IPatientService, IDepartmentService departmentService,ApplicationDbContext Context)
        {
            _IAppointmentService = IAppointmentService;
            _IDoctorService = IDoctorService;
            _IPatientService = IPatientService;
            _departmentService = departmentService;
            _context = Context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD:Hospital Management Project/Areas/Patient/Controllers/PatientAppointmentController.cs
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
=======
            var app = await _IAppointmentService.GetAllAppointmentsAsync();
            return View(app);
        }
>>>>>>> 7792b3037ee97070d0068123b064c6a9b15d8a23:Hospital Management Project/Areas/Patient/Controllers/AppointmentController.cs

			// Fetch the appointments for the logged-in patient
			var appointments = await _IAppointmentService.GetAppointmentsByPatientIdAsync(userId);

<<<<<<< HEAD:Hospital Management Project/Areas/Patient/Controllers/PatientAppointmentController.cs
			return View(appointments);
		}
=======
>>>>>>> 7792b3037ee97070d0068123b064c6a9b15d8a23:Hospital Management Project/Areas/Patient/Controllers/AppointmentController.cs
        [HttpGet]
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var viewModel = new AppoinmentVM
            {

                PatientID = userId,
                Departments = _context.Departments.Select(d => new SelectListItem
                {
                    Value = d.Id,
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
                Value = d.Id,
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
                    Value = d.Id,
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
                    Value = wh.Id,
                    Text = wh.Day + ": " + wh.StartHour + " - " + wh.EndHour
                }).ToList();

            return Json(workingHours);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var appoint = await _IAppointmentService.GetAppointmentByIdAsync(id);
            if (appoint == null)
            { 
                return NotFound();
            }
          
            var doctors = await _IDoctorService.GetAllDoctorsAsync();
            var patients = await _IPatientService.GetAllPatientsAsync();
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
            ViewBag.Department = departments.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.DepartmentName
            }).ToList();
            ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(Status)));

            return View(appoint);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appointment appointment)
        {
            if (ModelState.IsValid) 
            {
                await _IAppointmentService.UpdateAppointmentAsync(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _IAppointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction("Index");
        }
		public async Task<IActionResult> ViewDoctors(string Id)
		{
            List<Doctor> doctors=await _IDoctorService.GetByDepartmentId(Id);

			return View(doctors);
		}
	}
}
