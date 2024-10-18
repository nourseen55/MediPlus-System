using HospitalSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.ViewModels
{
    public class AppoinmentVM
    {
        public string AppointemntId {  get; set; }=Guid.NewGuid().ToString();
        public string PatientID { get; set; }
        public string? SelectedDepartmentID { get; set; }
        public string? SelectedDoctorID { get; set; }
        public string?SelectedWorkingHoursID { get; set; }
        public string? SelectedDepartmentName { get; set; }
        public string? SelectedDoctorName { get; set; }

        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? Doctors { get; set; }
        public IEnumerable<SelectListItem>? WorkingHours { get; set; }
    }
}
