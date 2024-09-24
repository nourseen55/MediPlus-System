using HospitalSystem.Application.Interfaces;

namespace HospitalSystem.Application.Services
{
    public class NurseService : INurseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NurseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddNurseAsync(Nurse Nurse)
        {
            await _unitOfWork._nurseRepository.AddEntityAsync(Nurse);
        }

        public async Task<Nurse> GetNurseByIdAsync(int id)
        {
            return await _unitOfWork._nurseRepository.GetEntityByIdAsync(id);
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _unitOfWork._nurseRepository.GetAllEntityAsync();
        }

        public async Task UpdateNurseAsync(Nurse Nurse)
        {
             await _unitOfWork._nurseRepository.UpdateEntityAsync(Nurse);
        }

        public async Task DeleteNurseAsync(int id)
        {
            await _unitOfWork._nurseRepository.DeleteEntityAsync(id);
        }
    }
}
