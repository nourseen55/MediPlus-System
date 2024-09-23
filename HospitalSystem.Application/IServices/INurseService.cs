namespace HospitalSystem.Application.Services
{
    public interface INurseService
    {
        Task AddNurseAsync(Nurse Nurse);
        Task<Nurse> GetNurseByIdAsync(int id);
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Task UpdateNurseAsync(Nurse Nurse);
        Task DeleteNurseAsync(int id);
    }
}
