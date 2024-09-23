namespace HospitalSystem.Core.Entities
{
    public class Patient:ApplicationUser
    {
        //Navigation Properties
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
    }
}
