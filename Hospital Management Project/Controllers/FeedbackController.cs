using HospitalSystem.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using X.PagedList;

namespace Hospital_Management_Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public FeedbackController(UserManager<ApplicationUser> userManager,ApplicationDbContext context )
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 4;


            var feedback =_context.feedbacks
                .Include(n => n.ApplicationUser)
                .OrderByDescending(n => n.DateFeedback)
                .ToPagedList(pageNum, pageSize);

            return View(feedback);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.UserId = _userManager.GetUserId(User);
                feedback.DateFeedback = DateTime.Now;   


                _context.feedbacks.Add(feedback);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            Feedback feedback = _context.feedbacks.FirstOrDefault(x => x.Id == id);

            _context.feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
