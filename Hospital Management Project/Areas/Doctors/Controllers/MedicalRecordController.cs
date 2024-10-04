using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Hospital_Management_Project.Areas.Doctors.Controllers{

    [Area("Doctors")]
    /*[Authorize(Roles =nameof(UserRoles.Doctor))]*/
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _medicalRecordService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService _fileService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService, IImageService fileService, IPatientService patientService , IAppointmentService appointmentService , UserManager<ApplicationUser> userManager)
        {
            _medicalRecordService = medicalRecordService;
            _patientService = patientService;
            _appointmentService = appointmentService;
            _userManager = userManager;
            _fileService = fileService;
            
            
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var doctorId = "fb32f999-bea2-46cf-b83c-de3321000b91";

            var patients = await _appointmentService.GetPatientsByDoctorAsync(doctorId);
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> RecordsByPatient(string id)
        {
            List<MedicalRecord> records = await _medicalRecordService.GetMedicalRecordsByPatientIdAsync(id);
            ViewBag.PatientId = id;
            return View(records);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string patientId)
        {
            var patient = await _patientService.GetPatientByIdAsync(patientId);
            if (patient == null) return NotFound();

            var user = await _userManager.GetUserAsync(User);

            MedicalRecord record = new MedicalRecord()
            {
                PatientID = patientId.ToString(),
                Patient = patient,
                DateOfEntry = DateTime.Now,
                DoctorID = "fb32f999-bea2-46cf-b83c-de3321000b91"
            };

            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalRecord record, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var path = @"DiagnosisDocument";
                    string FilePath = await _fileService.SaveImageAsync(file, path);
                    record.DiagnosisDocument = FilePath;
                }

                await _medicalRecordService.AddMedicalRecordAsync(record);
                return RedirectToAction("Index");
            }
            return View(record);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            MedicalRecord record = await _medicalRecordService.GetMedicalRecordAndPatientDetails(id);
            if (record == null) return NotFound();

            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MedicalRecord record, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(record.DiagnosisDocument != null)
                {
                    await _fileService.DeleteFileAsync(record.DiagnosisDocument);
                }

                if (file != null && file.Length > 0)
                {
                    var path = @"DiagnosisDocument";
                    string FilePath = await _fileService.SaveImageAsync(file, path);
                    record.DiagnosisDocument = FilePath;
                }

                await _medicalRecordService.UpdateMedicalRecordAsync(record);
                return RedirectToAction("Index", new { patientId = record.PatientID });
            }
            return View(record);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            MedicalRecord record = await _medicalRecordService.GetMedicalRecordByIdAsync(id);

            if (record.DiagnosisDocument != null)
            {
                await _fileService.DeleteFileAsync(record.DiagnosisDocument);
            }

            await _medicalRecordService.DeleteMedicalRecordAsync(id);

            return Json(new {success = true, message = "Medical Record has been Deleted Successfully"});
        }

        public async Task<IActionResult> Details(string id)
        {
            MedicalRecord? record = await _medicalRecordService.GetMedicalRecordAndPatientDetails(id);
            return View(record);
        }
    }
}
