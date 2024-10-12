using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Core.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.Application.IServices;
using X.PagedList;

namespace HospitalSystem.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService
        _imageService;

        public NewsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IImageService imageService)
        {
            _context = context;
            _userManager = userManager;
            _imageService = imageService;
        }

        // GET: News
        public IActionResult Index(int? page)
        {
            int pageNum = page ?? 1; // Default to page 1 if null
            int pageSize = 2; // Set your desired page size

            // Fetch and paginate the posts
            var posts = _context.NewsPosts
                .Include(n => n.User)
                .OrderByDescending(n => n.DatePosted)
                .ToPagedList(pageNum, pageSize);

            return View(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewsPost newsPost, IFormFile postImage)
        {
            if (ModelState.IsValid)
            {
                // Save the image
                var folderPath = "Images/Posts"; // Set the folder where images will be saved
                newsPost.PostImg = await _imageService.SaveImageAsync(postImage, folderPath); // Save image and set path
                newsPost.UserId = _userManager.GetUserId(User); // Get the logged-in user ID

                _context.NewsPosts.Add(newsPost);
                await _context.SaveChangesAsync();

                // Return the newly created post as a partial view
                return RedirectToAction("Index");
            }

            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            NewsPost post = _context.NewsPosts.FirstOrDefault(x => x.Id == id);
            _context.NewsPosts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
