namespace HospitalSystem.Core.Entities
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public string Treatment { get; set; }
        public string Diagnosis { get; set; }
        public DateTime DateOfEntry { get; set; } = DateTime.Now;
        public string PatientID { get; set; }
        public virtual Patient? Patient { get; set; }
        public string DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}