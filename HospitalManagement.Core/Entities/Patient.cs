using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Core.Entities
{
    public class Patient : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Img { get; set; }
        public string? ZipCode { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }


        public int Age()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
    }
    
}
