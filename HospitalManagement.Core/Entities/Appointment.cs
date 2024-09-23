namespace HospitalSystem.Core.Entities
{
    public class Appointment
    {
        public int AppointmentID { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDateTime { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDateTime { get; set; }
        public Status Status { get; set; }

        public string PatientID { get; set; }
        public virtual Patient? Patient { get; set; }
        public string DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}