using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Core.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using HospitalSystem.Application.IServices;
using X.PagedList;
using HospitalSystem.Application.Services;

namespace HospitalSystem.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService
        _imageService;

        public NewsController(INewsService newsService, UserManager<ApplicationUser> userManager, IImageService imageService)
        {
            _newsService = newsService;
            _userManager = userManager;
            _imageService = imageService;
        }

        // GET: News
        public async Task< IActionResult> Index(int? page)
        {
            int pageNum = page ?? 1; 
            int pageSize = 2; 
			IEnumerable<NewsPost> news = await _newsService.GetAllNewsAsync();
			var list = news.ToPagedList(pageNum, pageSize);

			return View(list);
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

               await _newsService.AddNewsAsync(newsPost);

                // Return the newly created post as a partial view
                return RedirectToAction("Index");
            }

            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
           await _newsService.DeleteNewsAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
