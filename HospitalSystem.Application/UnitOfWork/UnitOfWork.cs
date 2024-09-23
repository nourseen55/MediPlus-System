namespace HospitalSystem.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public IRepository<Patient> _patientRepository { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
            _patientRepository = new PatientRepository(applicationDbContext);

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
