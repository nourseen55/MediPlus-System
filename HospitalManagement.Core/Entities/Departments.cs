namespace HospitalSystem.Core.Entities
{
    public class Departments
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string DepartmentName { get; set; }
        public string? Description { get; set; }
        public string? Img {  get; set; }
        public virtual ICollection<Nurse>? Nurses { get; set; }
        public virtual ICollection<Doctor>? Doctors { get; set; }
        public virtual ICollection<MedicalRecord>? MedicalRecords{ get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
