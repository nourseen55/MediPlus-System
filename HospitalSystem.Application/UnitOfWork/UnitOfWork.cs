using HospitalSystem.Core.Entities;
using HospitalSystem.Core.IRepository;
using HospitalSystem.Infrastructure.Data;
using HospitalSystem.Infrastructure.Repository;

namespace HospitalSystem.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public IRepository<Patient> _patientRepository { get; private set; }

        public IRepository<Nurse> _nurseRepository  { get; private set; }

        public IRepository<Doctor> _doctorRepository { get; private set; }

        public IRepository<Appointment> _appointmentRepository { get; private set; }

        public IRepository<MedicalRecord> _recordRepository  { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _patientRepository = new PatientRepository(applicationDbContext);
            _nurseRepository = new NurseRepository(applicationDbContext);
            _doctorRepository = new DoctorRepository(applicationDbContext);
            _appointmentRepository = new AppointmentRepository(applicationDbContext);
            _recordRepository = new MedicalRecordRepository(applicationDbContext);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
