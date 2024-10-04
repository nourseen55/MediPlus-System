namespace HospitalSystem.Core.Entities
{
    public class MedicalRecord
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Treatment { get; set; }
        public string Diagnosis { get; set; }
        public DateTime DateOfEntry { get; set; } = DateTime.Now;
        public string? Response { get; set; }
        public string? PatientID { get; set; }
        public virtual Patient? Patient { get; set; }
        public string? DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public string? DiagnosisDocument { get; set; }
        public bool IsUnderMedicalCare { get; set; }
        public bool HasDrugAllergies { get; set; }
        public bool HasFoodOrEnvironmentalAllergies { get; set; }
        public bool HasDiabetes { get; set; } 
        public bool HasMentalHealthCareHistory { get; set; }
        public bool HasRestrictedEating { get; set; }
        public bool PatientChronicDisease { get; set; }
    }
}