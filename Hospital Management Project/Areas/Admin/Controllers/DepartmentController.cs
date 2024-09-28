using HospitalSystem.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
       private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
             _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var dept= await _departmentService.GetAllDepartmentsAsync();
            return View(dept);
        }
        public async Task<IActionResult> Details(string id)
        {
            var dept= await _departmentService.GetDepartmentByIdAsync(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departments departments)
        {
            if (ModelState.IsValid)
            {
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
