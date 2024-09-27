
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Appoint.Controllers
{
    [Area("Appoint")]
    public class AppointmentController : Controller
    {
       private readonly IAppointmentService _IAppointmentService;
        public AppointmentController(IAppointmentService IAppointmentService)
        {
            _IAppointmentService = IAppointmentService;
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
        public IActionResult Create()
        { 
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
        [HttpGet]
        public async Task< IActionResult> Delete(string id)
        {
            var app =await _IAppointmentService.GetAppointmentByIdAsync(id);
            return View(app);
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
