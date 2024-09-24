using HospitalSystem.Application.Interfaces;

namespace HospitalSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPatientAsync(Patient patient)
        {
            await _unitOfWork._patientRepository.AddEntityAsync(patient);
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _unitOfWork._patientRepository.GetEntityByIdAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _unitOfWork._patientRepository.GetAllEntityAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
             await _unitOfWork._patientRepository.UpdateEntityAsync(patient);
        }

        public async Task DeletePatientAsync(int id)
        {
            await _unitOfWork._patientRepository.DeleteEntityAsync(id);
        }
    }
}
