
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
    [Authorize(Roles = nameof(UserRoles.Patient))]
    public class AppointmentController : Controller
    {
       private readonly IAppointmentService _IAppointmentService;
        private readonly IDoctorService _IDoctorService;
        private readonly IPatientService _IPatientService;
        private readonly IDepartmentService _departmentService;
        public AppointmentController(IAppointmentService IAppointmentService, IDoctorService IDoctorService, IPatientService IPatientService, IDepartmentService departmentService)
        {
            _IAppointmentService = IAppointmentService;
            _IDoctorService = IDoctorService;
            _IPatientService = IPatientService;
            _departmentService = departmentService;
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
        public async Task<IActionResult> Create()
        {
            var doctors = await _IDoctorService.GetAllDoctorsAsync();
            var patients = await _IPatientService.GetAllPatientsAsync();
            var departments=await _departmentService.GetAllDepartmentsAsync();

            ViewBag.Doctors = doctors.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {              
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
                Text = d.Name
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
    }
}
