
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

        [HttpGet]
        public IActionResult Create()
        {
            var patient = new HospitalSystem.Core.Entities.Patient();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HospitalSystem.Core.Entities.Patient patient, IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                if (Img != null && Img.Length > 0)
                {
                    var path = @"Images\Patients";
                    string imgPath = await _imageService.SaveImageAsync(Img, path);
                    patient.Img = imgPath;
                }

                await _patientService.AddPatientAsync(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var Patient = await _patientService.GetPatientByIdAsync(id);
            if (Patient == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<PatientVM>(Patient);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientVM patientVM,IFormFile Img)
        {
            if (ModelState.IsValid)
            {
                
                var patient = await _patientService.GetPatientByIdAsync(patientVM.Id);
                if (patient == null)
                {
                    return NotFound();
                }
                var model = _mapper.Map(patientVM, patient);

                if (Img != null && Img.Length > 0) 
                {
                    var path = @"Images\Patients";
                    string imgPath = await _imageService.SaveImageAsync(Img, path);
                    patient.Img = imgPath; 
                }
                await _patientService.UpdatePatientAsync(patient);
                
                return RedirectToAction(nameof(Index));
            }
            return View(patientVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
