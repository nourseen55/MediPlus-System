namespace HospitalSystem.Core.IRepository
{
    public interface IRepository<T>where T:class
    {
        Task AddEntityAsync(T entity);
        Task<IEnumerable<T>> GetAllEntityAsync();
        Task<T> GetEntityByIdAsync(int id);
        Task UpdateEntityAsync(T entity);
        Task DeleteEntityAsync(int id);
    }
}
