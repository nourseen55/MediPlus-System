namespace HospitalSystem.Application.IServices
{
    public interface INewsService
	{
        Task AddNewsAsync(NewsPost news);
        Task<NewsPost> GetNewsByIdAsync(string id);
        Task<IEnumerable<NewsPost>> GetAllNewsAsync();
        Task DeleteNewsAsync(string id);
    }
}
