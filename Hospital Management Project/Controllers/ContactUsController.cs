using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Controllers
{
	public class ContactUsController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IEmailSender _emailSender;
		private readonly IMapper _mapper;

		public ContactUsController(UserManager<ApplicationUser> userManager , IEmailSender emailSender , IMapper mapper)
        {
			_userManager = userManager;
			_emailSender = emailSender;
			_mapper = mapper;
		}
        public async Task<IActionResult> Index()
		{
			var user = await _userManager.GetUserAsync(User);
			if(user == null)
			{
				return View(new ContactFormVM());
			}
			ContactFormVM contactForm =  _mapper.Map<ContactFormVM>(user);
			return View(contactForm);
		}

		[HttpPost]
		public async Task<IActionResult> Index(ContactFormVM model)
		{

			if (ModelState.IsValid)
			{
				var subject = model.Subject; 
				var message = $"<strong>Name:</strong> {model.FullName}<br/>" +
							  $"<strong>Email:</strong> {model.Email}<br/>" +
							  $"<strong>Phone:</strong> {model.PhoneNumber}<br/>" +
							  $"<strong>Message:</strong><br/>{model.Message}";

				try
				{
					await _emailSender.SendEmailAsync("hospitalmanagments@gmail.com", subject, message);
					TempData["SuccessMessage"] = "Thank you for contacting us. We will get back to you shortly.";
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("","There was an error sending your message: " + ex.Message);
				}
			}
			return View("Index", model);
		}
	}
}

