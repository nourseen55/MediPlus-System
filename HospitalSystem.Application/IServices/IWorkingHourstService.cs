namespace HospitalSystem.Application.IServices
{
    public interface IWorkingHourstService
	{
        Task AddHoursAsync(WorkingHours hours);
        Task<WorkingHours> GethoursByIdAsync(string id);
        Task<IEnumerable<WorkingHours>> GetAllWorkingHoursAsync();
        Task UpdatehoursAsync(WorkingHours Dept);
        Task DeletehoursAsync(string id);
       
    }
}
