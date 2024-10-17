using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Core.Entities
{
    public class Appointment
    {
        [Key]
        public string AppointmentID { get; set; } = Guid.NewGuid().ToString();

        [Display(Name = "Start Date")]
        public TimeSpan? StartDateTime { get; set; }
        [DataType(DataType.Date)]  // Date only
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly Day { get; set; }
        [Display(Name = "End Date")]
        public TimeSpan? EndDateTime { get; set; }
        public string PatientID { get; set; }

        [ValidateNever]
        public virtual Patient Patient { get; set; }

        public string? DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public string? DeptId { get; set; }
        public virtual Departments? Department { get; set; }



        public DateTime DateOfBirth { get; set; }

        public int CalculateAge()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }


    }
}
