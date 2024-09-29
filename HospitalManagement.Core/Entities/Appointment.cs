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
        public DateTime? StartDateTime { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDateTime { get; set; }
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

        // Constructor to initialize EndDateTime based on StartDateTime
        public DateTime? SetDefaultEndDateTime()
        {
            if (StartDateTime.HasValue)
            {
                EndDateTime = StartDateTime.Value.AddMinutes(3);
                return EndDateTime;
            }
            return null;
            

        }
    }
}
