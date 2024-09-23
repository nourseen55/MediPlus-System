namespace HospitalSystem.Application.Services
{
    public interface IPatientService
    {
        Task AddPatientAsync(Patient patient);
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
    }
}
