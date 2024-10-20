namespace HospitalSystem.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
            
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;

        public IGenericRepository<Patient> _patientRepository { get; private set; }

        public IGenericRepository<Nurse> _nurseRepository  { get; private set; }

        public IDoctorRepository _doctorRepository { get; private set; }

        public IAppointmentRepository _appointmentRepository { get; private set; }

        public IMedicalRecordRepository _recordRepository  { get; private set; }

        public IGenericRepository<Departments> _departmentsRepository { get; private set; }

		public IGenericRepository<Feedback> _feedbacksRepository { get; private set; }

		public IGenericRepository<NewsPost> _newsRepository { get; private set; }

		public IGenericRepository<WorkingHours> _hoursRepository { get; private set; }

        public IGenericRepository<Education> _educationRepository {  get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext,UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _context = applicationDbContext;
            _userManager = userManager;
            _userStore = userStore;
            _patientRepository = new PatientRepository(applicationDbContext);
            _nurseRepository = new NurseRepository(applicationDbContext,_userManager,_userStore);
            _doctorRepository = new DoctorRepository(applicationDbContext,_userManager, _userStore);
            _appointmentRepository = new AppointmentRepository(applicationDbContext);
            _recordRepository = new MedicalRecordRepository(applicationDbContext);
            _departmentsRepository = new DpartmentRepository(applicationDbContext);
            _feedbacksRepository=new FeedbackRepository(applicationDbContext);
            _newsRepository=new NewsRepository(applicationDbContext);
            _hoursRepository =new WorkingHoursRepository(applicationDbContext);
            _educationRepository =new EducationRepository(applicationDbContext);

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
