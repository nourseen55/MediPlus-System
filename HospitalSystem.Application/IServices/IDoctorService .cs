namespace HospitalSystem.Application.Services
{
    public interface IDoctorService
    {
        Task AddDoctorAsync(Doctor Doctor);
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task UpdateDoctorAsync(Doctor Doctor);
        Task DeleteDoctorAsync(int id);
    }
}
