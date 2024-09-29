using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Core.Entities
{
    public class Doctor : IdentityUser
    {
        public string? Name { get; set; }
        public string? Img { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Age()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
        public string DepartmentId { get; set; }
        public virtual Departments? Department { get; set; }

        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<Nurse>? Nurses { get; set; }

    }
}