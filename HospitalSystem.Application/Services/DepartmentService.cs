namespace HospitalSystem.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddDepartmentAsync(Departments dept)
        {
            await _unitOfWork._departmentsRepository.AddEntityAsync(dept);
        }
     
        public async Task DeleteDepartmentAsync(string id)
        {
            await _unitOfWork._departmentsRepository.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<Departments>> GetAllDepartmentsAsync()
        {
            return await _unitOfWork._departmentsRepository.GetAllEntityAsync();
        }

        public async Task<Departments> GetDepartmentByIdAsync(string id)
        {
            return await _unitOfWork._departmentsRepository.GetEntityByIdAsync(id);
        }

        public async Task UpdateDepartmentAsync(Departments Dept)
        {
           await _unitOfWork._departmentsRepository.UpdateEntityAsync(Dept);    
        }
    }
}
