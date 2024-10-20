namespace HospitalSystem.Application.IServices
{
    public interface IFeedbackService
	{
        Task AddFeedbackAsync(Feedback feedback);
        Task<Feedback> GetFeedbackByIdAsync(string id);
        Task<IEnumerable<Feedback>> GetAllfeedbacksAsync();
        Task DeleteFeedbackAsync(string id);
    }
}
