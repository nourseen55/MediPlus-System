using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    [Authorize(Roles = nameof(UserRoles.Doctor))]
    public class WorkingHourController : Controller
    {
        private readonly IWorkingHourstService _hourservice;
        private UserManager<ApplicationUser> _usermanager;
        public WorkingHourController(IWorkingHourstService service, UserManager<ApplicationUser> usermanager)
        {
            _hourservice = service;
            _usermanager = usermanager;
        }
        public async Task< IActionResult> Index()
        {
            var hours = await _hourservice.GetAllWorkingHoursAsync();
            var user = await _usermanager.GetUserAsync(User);  // انتظار النتيجة بشكل صحيح
            var myhours = hours.Where(x => x.DoctorId == user.Id).ToList();  // تصحيح عملية المقارنة

            return View(myhours);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _usermanager.GetUserAsync(User);  // انتظار النتيجة بشكل صحيح
            WorkingHours workingHours=new WorkingHours();
            workingHours.DoctorId = user.Id;
            return View(workingHours);

        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkingHours workingHours)
        {
            if (ModelState.IsValid)
            {
                await _hourservice.AddHoursAsync(workingHours);
                return RedirectToAction("Index");

            }
            return View(workingHours);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var workingHours = await _hourservice.GethoursByIdAsync(id);
            if (workingHours == null)
            {
                return NotFound();
            }
            var user = await _usermanager.GetUserAsync(User);
            workingHours.DoctorId = user.Id;
            return View(workingHours);

        }
    
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(WorkingHours workingHours)
        {
            if (ModelState.IsValid)
            {
                var originalEntity = await _hourservice.GethoursByIdAsync(workingHours.Id);
                if (originalEntity == null)
                {
                    return NotFound();
                }

                originalEntity.Day = workingHours.Day;
                originalEntity.StartHour = workingHours.StartHour;
                originalEntity.EndHour = workingHours.EndHour;

                await _hourservice.UpdatehoursAsync(originalEntity);

                return RedirectToAction("Index");
            }
            return View(workingHours);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _hourservice.DeletehoursAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
