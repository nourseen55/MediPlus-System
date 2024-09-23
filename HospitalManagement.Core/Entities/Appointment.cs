namespace HospitalSystem.Core.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDateTime { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDateTime { get; set; }

        [Required]
        public Status Status { get; set; }

        [ForeignKey("Patient")]
        public string PatientID { get; set; }
        public virtual Patient? Patient { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}