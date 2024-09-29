using AutoMapper;
using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital_Management_Project.Areas.Admin.Controllers
{ 
    [Area("Admin")]
    public class NurseController : Controller
    {
       private readonly INurseService _nurseService;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IDoctorService _DoctorService;
        private readonly IDepartmentService _departmentService;
        public NurseController(INurseService nurseService,IMapper mapper,IImageService imageService,IDepartmentService departmentService,IDoctorService doctorService)
        {
            _nurseService = nurseService;
            _mapper = mapper;
            _imageService = imageService;
            _DoctorService = doctorService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var Nurse = await _nurseService.GetAllNursesAsync();
            return View(Nurse);
        }
        public async Task<IActionResult> Details(string id)
        {
            var Nurse= await _nurseService.GetNurseByIdAsync(id);   
            if (Nurse == null)
            {
                return NotFound();
            }
            return View(Nurse);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var doctors=await _DoctorService.GetAllDoctorsAsync();
            var dept = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Doctors = doctors.Select(d => new SelectListItem
            {
                Value = d.Id,
                Text = d.Name
            }).ToList();

            ViewBag.Dept = dept.Select(d => new SelectListItem
            {
                Value=d.Id,
                Text = d.DepartmentName
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Nurse nurse, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images\Nurses";
                    string imgPath = await _imageService.SaveImageAsync(Img, path);
                    nurse.Img = imgPath;
                }
               

                await _nurseService.AddNurseAsync(nurse);
                return RedirectToAction("Index");
            }
            return View(nurse);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var nurse = await _nurseService.GetNurseByIdAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<NurseVM>(nurse);
            var doctors = await _DoctorService.GetAllDoctorsAsync();
            var dept = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Doctors = doctors.Select(d => new SelectListItem
            {
                Value = d.Id,
                Text = d.Name
            }).ToList();

            ViewBag.Dept = dept.Select(d => new SelectListItem
            {
                Value = d.Id,
                Text = d.DepartmentName
            }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NurseVM nurseVM, IFormFile Img)
        {
            if (ModelState.IsValid)
            {

                var nurse = await _nurseService.GetNurseByIdAsync(nurseVM.ID);
                if (nurse == null)
                {
                    return NotFound();
                }
                var model = _mapper.Map(nurseVM, nurse);

                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images\Nurses";
                    string imgPath = await _imageService.SaveImageAsync(Img, path);
                    nurse.Img = imgPath;
                }
                await _nurseService.UpdateNurseAsync(nurse);

                return RedirectToAction(nameof(Index));
            }
            return View(nurseVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _nurseService.DeleteNurseAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
