using HospitalSystem.Application.IServices;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    [Authorize(Roles = nameof(UserRoles.Doctor))]
    public class WorkingHourController : Controller
    {
        private readonly IWorkingHourstService _hourservice;
        private UserManager<ApplicationUser> _usermanager;
        private readonly ApplicationDbContext _context;

        public WorkingHourController(IWorkingHourstService service, UserManager<ApplicationUser> usermanager,ApplicationDbContext Context)
        {
            _hourservice = service;
            _usermanager = usermanager;
            _context = Context;
        }
        public async Task< IActionResult> Index()
        {
            var hours = await _hourservice.GetAllWorkingHoursAsync();
            var user = await _usermanager.GetUserAsync(User);  
            var myhours = hours.Where(x => x.DoctorId == user.Id).ToList(); 

            return View(myhours);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await _usermanager.GetUserAsync(User);  
            WorkingHours workingHours=new WorkingHours();
            workingHours.DoctorId = user.Id;
            return View(workingHours);

        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkingHours workingHours)
        {
            if (ModelState.IsValid)
            {
                var existinghours = await GetWorkingHoursByDayAndTimeAsync(workingHours.DoctorId,workingHours.Day,workingHours.StartHour,workingHours.EndHour);
                
                if(existinghours != null)
                {
                    ModelState.AddModelError("", "The working hours for this day and time already exist.");
                    return View(workingHours);
                }
                if (workingHours.Day < DateOnly.FromDateTime(DateTime.Now))
                {
                    ModelState.AddModelError("", "The working hours cannot be set in the past.");
                    return View(workingHours);
                }
                await _hourservice.AddHoursAsync(workingHours);
                return RedirectToAction("Index");

            }
            return View(workingHours);
        }
        public async Task<WorkingHours> GetWorkingHoursByDayAndTimeAsync(string doctorId, DateOnly Day, TimeSpan startHour, TimeSpan endHour)
        {
            return await _context.WorkingHours.FirstOrDefaultAsync(wh => wh.DoctorId == doctorId &&
            wh.Day == Day&& 
            ((startHour >= wh.StartHour && startHour < wh.EndHour) ||
            (endHour > wh.StartHour && endHour <= wh.EndHour) ||
            (startHour < wh.StartHour && endHour > wh.EndHour)));
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

        [HttpPost]
        public async Task<IActionResult> Edit(WorkingHours workingHours)
        {
            var originalEntity = await _hourservice.GethoursByIdAsync(workingHours.Id);
            if (originalEntity == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingHours = await GetWorkingHoursByDayAndTimeAsync(
                    workingHours.DoctorId,
                    workingHours.Day,
                    workingHours.StartHour,
                    workingHours.EndHour
                );
                

                if (existingHours != null && existingHours.Id != originalEntity.Id)
                {
                    ModelState.AddModelError("", "The working hours for this day and time already exist.");
                    return View(workingHours);
                }
                if (workingHours.Day < DateOnly.FromDateTime(DateTime.Now))
                {
                    ModelState.AddModelError("", "The working hours cannot be set in the past.");
                    return View(workingHours);
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
