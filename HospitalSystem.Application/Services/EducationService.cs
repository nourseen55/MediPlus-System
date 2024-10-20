namespace HospitalSystem.Application.Services
{
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddEducationAsync(Education education)
        {
           await _unitOfWork._educationRepository.AddEntityAsync(education);
        }

        public async Task DeleteEducationAsync(string id)
        {
            await _unitOfWork._educationRepository.DeleteEntityAsync(id);
        }

        public async Task<IEnumerable<Education>> GetAllEducationAsync()
        {
            return await _unitOfWork._educationRepository.GetAllEntityAsync();
        }

        public async Task<Education> GetEducationIdAsync(string id)
        {
            return await _unitOfWork._educationRepository.GetEntityByIdAsync(id); 
        }

        public async Task UpdateEducationAsync(Education Dept)
        {
             await _unitOfWork._educationRepository.UpdateEntityAsync(Dept);
        }
    }
}
