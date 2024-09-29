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
        int Complete();

    }
}
