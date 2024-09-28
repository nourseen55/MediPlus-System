namespace HospitalSystem.Application.Services
{
    public interface INurseService
    {
        Task AddNurseAsync(Nurse Nurse);
        Task<Nurse> GetNurseByIdAsync(string id);
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Task UpdateNurseAsync(Nurse Nurse);
        Task DeleteNurseAsync(string id);
    }
}
