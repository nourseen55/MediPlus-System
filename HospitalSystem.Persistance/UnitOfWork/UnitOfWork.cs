namespace HospitalSystem.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public IGenericRepository<Patient> _patientRepository { get; private set; }

        public IGenericRepository<Nurse> _nurseRepository  { get; private set; }

        public IDoctorRepository _doctorRepository { get; private set; }

        public IAppointmentRepository _appointmentRepository { get; private set; }

        public IMedicalRecordRepository _recordRepository  { get; private set; }

        public IGenericRepository<Departments> _departmentsRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _patientRepository = new PatientRepository(applicationDbContext);
            _nurseRepository = new NurseRepository(applicationDbContext);
            _doctorRepository = new DoctorRepository(applicationDbContext);
            _appointmentRepository = new AppointmentRepository(applicationDbContext);
            _recordRepository = new MedicalRecordRepository(applicationDbContext);
            _departmentsRepository = new DpartmentRepository(applicationDbContext);
            

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
