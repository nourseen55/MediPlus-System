namespace HospitalSystem.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Patient> _patientRepository { get; }
        IGenericRepository<Nurse> _nurseRepository { get; }
        IDoctorRepository _doctorRepository { get; }
        IAppointmentRepository _appointmentRepository { get; }
        IMedicalRecordRepository _recordRepository { get; }
        IGenericRepository<Departments> _departmentsRepository { get; }
        IGenericRepository<Feedback> _feedbacksRepository { get; }
        IGenericRepository<NewsPost> _newsRepository { get; }
        IGenericRepository<WorkingHours> _hoursRepository { get; }
        IGenericRepository<Education> _educationRepository { get; }
        int Complete();

    }
}
