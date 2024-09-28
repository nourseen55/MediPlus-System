
using AutoMapper;
using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IImageService _imageService;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        public DoctorController(IDoctorService doctorService, IImageService imageService, IMapper mapper, IWebHostEnvironment webHostEnvironment, UserManager<IdentityUser> userManager)
        {
            _doctorService = doctorService;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
            _imageService = imageService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Doctor doctor = new Doctor();
            return View(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images/Doctors/";

                    doctor.Img = await _imageService.SaveImageAsync(Img, path);
                }
                await _doctorService.AddDoctorAsync(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);

        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            var doctorvm = mapper.Map<DoctorVM>(doctor);
            return View(doctorvm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DoctorVM doctorvm, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(doctorvm.Id);
                mapper.Map(doctorvm, doctor);
                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images/Doctors/";
                    doctor.Img = await _imageService.SaveImageAsync(Img, path);

                }
                await _doctorService.UpdateDoctorAsync(doctor);
                return RedirectToAction("Index");
            }
            return View(doctorvm);
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
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }
    }
}
