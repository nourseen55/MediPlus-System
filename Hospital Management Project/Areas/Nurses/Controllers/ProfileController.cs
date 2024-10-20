namespace Hospital_Management_Project.Areas.Nurses.Controllers
{
    [Area("Nurses")]

    public class ProfileController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly INurseService _nurseService;
        public ProfileController(UserManager<ApplicationUser> userManager,INurseService nurseService)
        {
			_userManager = userManager;
			_nurseService = nurseService;
        }

        public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			Nurse? nurse =await _nurseService.GetNurseByIdAsync(user.Id);

			return View(nurse);
		}
	}
}
