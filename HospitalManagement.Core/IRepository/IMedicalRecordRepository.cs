using HospitalSystem.Core.Entities;

namespace HospitalSystem.Core.IRepository
{
    public interface IMedicalRecordRepository : IGenericRepository<MedicalRecord>
    {
        Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAsync(string patientId);
        Task<MedicalRecord> GetMedicalRecordAndPatientDetails(string id);
    }
}
