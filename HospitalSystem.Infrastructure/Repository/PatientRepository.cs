
namespace HospitalSystem.Infrastructure.Repository
{
    public class PatientRepository : IGenericRepository<Patient>
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(Patient entity)
        {
            _context.Patients.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllEntityAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetEntityByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var patient = await GetEntityByIdAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
