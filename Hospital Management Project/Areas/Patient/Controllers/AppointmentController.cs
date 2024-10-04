
using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Management_Project.Areas.Appoint.Controllers
{
    [Area("Patient")]
    //[Authorize(Roles = nameof(UserRoles.Patient))]
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
        public async Task< IActionResult> Details(string id) 
        { 
            var app= await _IAppointmentService.GetAppointmentByIdAsync(id);
            if (app == null) 
            { 
                return NotFound();
            }
            return View(app);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string DoctorID)
        {
            var appointment = new Appointment()
            {
                DoctorID = DoctorID,
                PatientID = _userManager.GetUserId(User) // Get the current user's ID
            };

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(appointment.DoctorID) || string.IsNullOrEmpty(appointment.PatientID))
                {
                    ModelState.AddModelError(string.Empty, "Doctor and Patient information is required.");
                    return View(appointment);
                }

                Doctor doctor = await _IDoctorService.GetDoctorByIdAsync(appointment.DoctorID);
                //doctor.Status = false; // Change this logic based on your requirements

                await _IAppointmentService.AddAppointmentAsync(appointment);
                return RedirectToAction("Index");
            }

            return View(appointment);
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
