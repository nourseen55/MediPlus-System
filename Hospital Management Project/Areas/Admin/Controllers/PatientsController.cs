
using AutoMapper;
using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Entities;
using HospitalSystem.Core.Enums;
using HospitalSystem.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Project.Areas.Patient.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class PatientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;
        private readonly IImageService _imageService;
        public PatientController(IPatientService patientService, IImageService imageService, IMapper mapper)
        {
            _patientService = patientService;
            _imageService = imageService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Patient = await _patientService.GetAllPatientsAsync();
            return View(Patient);
        }
        public async Task<IActionResult> Details(string id)
        {
            var Patient = await _patientService.GetPatientByIdAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }
            return View(Patient);
        }

      
       
    }
}
