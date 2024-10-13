using HospitalSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Hospital_Management_Project.Areas.Patient.Controllers
{
	[Area("Patient")]
	public class MedicalRecordController : Controller
	{
		private readonly IMedicalRecordService _medicalRecordService;
		private readonly UserManager<ApplicationUser> _user;

		public MedicalRecordController(IMedicalRecordService medicalRecordService,UserManager<ApplicationUser> user)
        {
			_medicalRecordService = medicalRecordService;
			_user = user;
		}
        public async Task<IActionResult> Index(int? page)
		{
            int pageNum = page ?? 1;
            int pageSize = 3; 

            var user =await _user.GetUserAsync(User);
			var patient = await _medicalRecordService.GetMedicalRecordsByPatientIdAsync(user.Id.ToString());
			var pagenatedpatient=patient.ToPagedList(pageNum, pageSize);	
			return View(pagenatedpatient);

		}
	}
}
