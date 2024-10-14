using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRoles.Admin))]
    public class DashboardController : Controller
    {
        private readonly IDoctorService _IdoctorService;
        private readonly IPatientService _IpatientService;
        private readonly IDepartmentService _IdepartmentService;
        private readonly INurseService _InurseService;
        private readonly IUnitOfWork _IunitOfWork;
        public DashboardController(IDoctorService IdoctorService, IPatientService IpatientService,
            IDepartmentService IdepartmentService, INurseService InurseService, IUnitOfWork IunitOfWork)
        {
            _IdepartmentService = IdepartmentService;
            _InurseService = InurseService;
            _IdoctorService= IdoctorService;
            _IpatientService= IpatientService;
            _IunitOfWork= IunitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await _IpatientService.GetAllPatientsAsync();
            var doctors = await _IdoctorService.GetAllDoctorsAsync();
            var departments = await _IdepartmentService.GetAllDepartmentsAsync();
            var nurses = await _InurseService.GetAllNursesAsync();

            ViewBag.PatientCount = patients.Count();
            ViewBag.DoctorCount = doctors.Count();
            ViewBag.DepartmentCount = departments.Count();
            ViewBag.NurseCount = nurses.Count();
            return View();
        }
    }
}
