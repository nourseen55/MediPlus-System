using HospitalSystem.Core.Entities;
using HospitalSystem.Core.IRepository;

namespace HospitalSystem.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Patient> _patientRepository { get; }
        IRepository<Nurse> _nurseRepository { get; }
        IRepository<Doctor> _doctorRepository { get; }
        IRepository<Appointment> _appointmentRepository { get; }
        IRepository<MedicalRecord> _recordRepository { get; }
        int Complete();

    }
}
