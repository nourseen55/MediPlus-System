using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Core.Entities
{
    public class Patient : ApplicationUser
    {
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
    }
    
}
