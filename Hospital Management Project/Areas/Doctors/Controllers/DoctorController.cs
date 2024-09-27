
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
namespace Hospital_Management_Project.Areas.Doctors.Controllers
{
    [Area("Doctors")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public DoctorController(IDoctorService doctorService,IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _doctorService = doctorService;   
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task< IActionResult> Create()
        {
            Doctor doctor =new Doctor();
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var environment = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    var filename=Guid.NewGuid().ToString();
                    var path=Path.Combine(environment,@"Images/Doctors");
                    var ext=Path.GetExtension(file.FileName);
                    using (var filestream = new FileStream(Path.Combine(path, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    doctor.Img = @"Images/Doctors/" + filename + ext;
                }
                doctor.UserName = doctor.Email;
                await _doctorService.AddDoctorAsync(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);

        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            return View(doctor);
        }
            [HttpPost]
        public async Task<IActionResult> Update(Doctor doctor, IFormFile file) // 'file' should match the input name attribute
        {
            if (ModelState.IsValid)
            {
                var environment = _webHostEnvironment.WebRootPath;
                if (file != null && file.Length > 0) // Ensure the file is not null
                {
                    var filename = Guid.NewGuid().ToString();
                    var path = Path.Combine(environment, "Images", "Doctors");

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    var ext = Path.GetExtension(file.FileName);

                    // If an old image exists, delete it
                    if (!string.IsNullOrEmpty(doctor.Img))
                    {
                        var oldImagePath = Path.Combine(environment, doctor.Img.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(path, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    doctor.Img = @"Images/Doctors/" + filename + ext;
                }

                await _doctorService.UpdateDoctorAsync(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index()
        {
           var doctors =await  _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }
    }
}
