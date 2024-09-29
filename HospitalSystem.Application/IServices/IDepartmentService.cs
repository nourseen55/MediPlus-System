using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Application.IServices
{
    public interface IDepartmentService
    {
        Task AddDepartmentAsync(Departments dept);
        Task<Departments> GetDepartmentByIdAsync(string id);
        Task<IEnumerable<Departments>> GetAllDepartmentsAsync();
        Task UpdateDepartmentAsync(Departments Dept);
        Task DeleteDepartmentAsync(string id);
    }
}
