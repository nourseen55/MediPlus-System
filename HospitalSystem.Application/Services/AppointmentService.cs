namespace HospitalSystem.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAppointmentAsync(Appointment Appointment)
        {
            await _unitOfWork._appointmentRepository.AddEntityAsync(Appointment);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _unitOfWork._appointmentRepository.GetEntityByIdAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _unitOfWork._appointmentRepository.GetAllEntityAsync();
        }

        public async Task UpdateAppointmentAsync(Appointment Appointment)
        {
             await _unitOfWork._appointmentRepository.UpdateEntityAsync(Appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            await _unitOfWork._appointmentRepository.DeleteEntityAsync(id);
        }
    }
}
