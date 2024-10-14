using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Core.Entities
{
    public class Doctor : ApplicationUser
    {
        public bool Status { get; set; } = true;
        public string DepartmentId { get; set; }

        public virtual Departments? Department { get; set; }
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Nurse>? Nurses { get; set; }
        public virtual ICollection<Education>? Educations { get; set; }
        public virtual ICollection<WorkingHours>? WorkingHours { get; set; }
        
    }
}