namespace HospitalSystem.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Patient> _patientRepository { get; }
        IGenericRepository<Nurse> _nurseRepository { get; }
        IGenericRepository<Doctor> _doctorRepository { get; }
        IGenericRepository<Appointment> _appointmentRepository { get; }
        IGenericRepository<MedicalRecord> _recordRepository { get; }
        IGenericRepository<Departments> _departmentsRepository { get; }
        int Complete();

    }
}
