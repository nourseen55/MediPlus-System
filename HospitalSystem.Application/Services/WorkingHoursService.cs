using HospitalSystem.Application.Interfaces;
using HospitalSystem.Application.IServices;

namespace HospitalSystem.Application.Services
{
    public class WorkingHoursService : IWorkingHourstService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkingHoursService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task AddHoursAsync(WorkingHours hours)
		{
			await _unitOfWork._hoursRepository.AddEntityAsync(hours);
		}

		public async Task DeletehoursAsync(string id)
		{
			await _unitOfWork._hoursRepository.DeleteEntityAsync(id);
		}

		public async Task<IEnumerable<WorkingHours>> GetAllWorkingHoursAsync()
		{
			return await _unitOfWork._hoursRepository.GetAllEntityAsync();
		}


        public  async Task<WorkingHours> GethoursByIdAsync(string id)
		{
			return await _unitOfWork._hoursRepository.GetEntityByIdAsync(id);
		}

		public async Task UpdatehoursAsync(WorkingHours hours)
		{
			await _unitOfWork._hoursRepository.UpdateEntityAsync(hours);
		}
	}
}
