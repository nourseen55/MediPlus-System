namespace Hospital_Management_Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(UserManager<ApplicationUser> userManager,IFeedbackService feedbackService )
        {
            _userManager = userManager;
            _feedbackService = feedbackService;
        }
        [HttpGet]
        public async Task< IActionResult> Index(int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 4;
            IEnumerable<Feedback> feedbacks = await _feedbackService.GetAllfeedbacksAsync();
            var list=feedbacks.ToPagedList(pageNum, pageSize);
			return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.UserId = _userManager.GetUserId(User);
                feedback.DateFeedback = DateTime.Now;   
               await _feedbackService.AddFeedbackAsync(feedback);
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _feedbackService.DeleteFeedbackAsync(id);
            return RedirectToAction("Index");

        }
    }
}
