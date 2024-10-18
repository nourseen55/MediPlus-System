﻿using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;


namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class AppointmentController : Controller
    {
       private readonly IAppointmentService _IAppointmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public AppointmentController(IAppointmentService IAppointmentService, UserManager<ApplicationUser> userManager)
        {
            _IAppointmentService = IAppointmentService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var app= await _IAppointmentService.GetAllAppointmentsAsync();
            return View(app);
        }

       

    }
}
