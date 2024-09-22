using HospitalSystem.Core.Entities;
using HospitalSystem.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientService(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _patientRepository.AddEntityAsync(patient);
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetEntityByIdAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _patientRepository.GetAllEntityAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            await _patientRepository.UpdateEntityAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeleteEntityAsync(id);
        }
    }
}
