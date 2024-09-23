namespace HospitalSystem.Application.Services
{
    public interface IAppointmentService
    {
        Task AddAppointmentAsync(Appointment Appointment);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task UpdateAppointmentAsync(Appointment Appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
