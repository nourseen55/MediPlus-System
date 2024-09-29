using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;

namespace Hospital_Management_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public HomeController(ILogger<HomeController> logger,IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        public async Task< IActionResult> Index()
        {
            var department=await _departmentService.GetAllDepartmentsAsync();
			return View(department);
        }

    }
}
