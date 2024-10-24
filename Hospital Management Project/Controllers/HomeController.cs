namespace Hospital_Management_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger,IDepartmentService departmentService,UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _departmentService = departmentService;
            _userManager = userManager;
        }
		
		public async Task< IActionResult> Index()
        {
            var department=await _departmentService.GetAllDepartmentsAsync();
			return View(department);
        }
        public async Task<IActionResult> Details(string Id)
        {
            var dept = await _departmentService.GetDepartmentByIdAsync(Id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
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
                case 403:
                    ViewData["ErrorMessage"] = "You are not authorized to access this page";
                    return View("Error", errorViewModel);
                default:
                    ViewData["ErrorMessage"] = "An unexpected error occurred.";
                    return View("Error", errorViewModel);
            }
        }

    }
}
