namespace HospitalSystem.Application.IServices
{
    public interface IEducationService
    {
        Task AddEducationAsync(Education education);
        Task<Education> GetEducationIdAsync(string id);
        Task<IEnumerable<Education>> GetAllEducationAsync();
        Task UpdateEducationAsync(Education Dept);
        Task DeleteEducationAsync(string id);
    }
}
