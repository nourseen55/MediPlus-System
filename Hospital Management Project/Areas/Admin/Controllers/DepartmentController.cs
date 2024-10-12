using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
       private readonly IDepartmentService _departmentService;
       private readonly IImageService _imageservice;
        public DepartmentController(IDepartmentService departmentService,IImageService imageService)
        {
             _departmentService = departmentService;
            _imageservice = imageService;
        }
        public async Task<IActionResult> Index()
        {
            var dept= await _departmentService.GetAllDepartmentsAsync();
            return View(dept);
        }
     
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departments departments,IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                
                    if (Img != null && Img.Length > 0)
                    {
                        var path = @"Images/Departments/";

                        departments.Img = await _imageservice.SaveImageAsync(Img, path);
                    }
                    await _departmentService.AddDepartmentAsync(departments);
                return RedirectToAction("Index");
            }
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var dept = await _departmentService.GetDepartmentByIdAsync(id);
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Departments departments)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.UpdateDepartmentAsync(departments);
                return RedirectToAction("Index");
            }
            return View(departments);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var dept = await _departmentService.GetDepartmentByIdAsync(id);
            return View(dept);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction("Index");
        }

    }
}
