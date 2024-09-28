namespace HospitalSystem.Application.Services
{
    public interface IAppointmentService
    {
        Task AddAppointmentAsync(Appointment Appointment);
        Task<Appointment> GetAppointmentByIdAsync(string id);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task UpdateAppointmentAsync(Appointment Appointment);
        Task DeleteAppointmentAsync(string id);
    }
}
