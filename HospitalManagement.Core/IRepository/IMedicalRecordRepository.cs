using HospitalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Core.IRepository
{
    public interface IMedicalRecordRepository
    {
        Task AddEntityAsync(MedicalRecord entity);
        Task<IEnumerable<MedicalRecord>> GetAllEntityAsync();
        Task<MedicalRecord?> GetEntityByIdAsync(int id);
        Task UpdateEntityAsync(MedicalRecord entity);
        Task DeleteEntityAsync(int id);
        Task<List<MedicalRecord>> GetMedicalRecordsByPatientIdAsync(string patientId);
        Task<MedicalRecord> GetMedicalRecordAndPatientDetails(int id);
    }
}
