
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
        public Status Status { get; set; }

        public string? PatientID { get; set; }
        public virtual Patient? Patient { get; set; }
        public string? DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int CalculateAge()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
    }
}