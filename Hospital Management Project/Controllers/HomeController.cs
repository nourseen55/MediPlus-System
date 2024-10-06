using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using Microsoft.AspNetCore.Http;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                StatusCode = statusCode
            };

			switch (statusCode)
            {
                case 404:
                    ViewData["ErrorMessage"] = "Sorry, the page you are looking for could not be found.";
                    return View("Error", errorViewModel);
                case 500:
                    ViewData["ErrorMessage"] = "Sorry, something went wrong on our end.";
                    return View("Error", errorViewModel);
                default:
                    ViewData["ErrorMessage"] = "An unexpected error occurred.";
                    return View("Error", errorViewModel);
            }
        }

    }
}
