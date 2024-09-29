using HospitalSystem.Application.Interfaces;

namespace HospitalSystem.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddDoctorAsync(Doctor Doctor)
        {
            await _unitOfWork._doctorRepository.AddEntityAsync(Doctor);
        }

        public async Task<Doctor> GetDoctorByIdAsync(string id)
        {
            return await _unitOfWork._doctorRepository.GetEntityByIdAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _unitOfWork._doctorRepository.GetAllEntityAsync();
        }

        public async Task UpdateDoctorAsync(Doctor Doctor)
        {
             await _unitOfWork._doctorRepository.UpdateEntityAsync(Doctor);
        }

        public async Task DeleteDoctorAsync(string id)
        {
            await _unitOfWork._doctorRepository.DeleteEntityAsync(id);
        }

		public async Task<List<Doctor>> GetByDepartmentId(string Id)
		{
			return await _unitOfWork._doctorRepository.GetByDepartmentId(Id);
		}
	}
}
