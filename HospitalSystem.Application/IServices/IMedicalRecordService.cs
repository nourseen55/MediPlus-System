namespace HospitalSystem.Application.Services
{
    public interface IMedicalRecordService
    {
        Task AddMedicalRecordAsync(MedicalRecord MedicalRecord);
        Task<MedicalRecord> GetMedicalRecordByIdAsync(string id);
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync();
        Task UpdateMedicalRecordAsync(MedicalRecord MedicalRecord);
        Task DeleteMedicalRecordAsync(string id);
        Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAsync(string patientId);
        Task<MedicalRecord?> GetMedicalRecordAndPatientDetails(int id);
    }
}
