using HospitalSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Infrastructure.IRepository
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
