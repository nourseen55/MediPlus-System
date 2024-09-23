
namespace HospitalSystem.Infrastructure.Repository
{
    public class NurseRepository : IGenericRepository<Nurse>
    {

        private readonly ApplicationDbContext _context;

        public NurseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(Nurse entity)
        {
            _context.Nurses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nurse>> GetAllEntityAsync()
        {
            return await _context.Nurses.ToListAsync();
        }

        public async Task<Nurse?> GetEntityByIdAsync(int id)
        {
            return await _context.Nurses.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Nurse entity)
        {
            _context.Nurses.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var Nurse = await GetEntityByIdAsync(id);
            if (Nurse != null)
            {
                _context.Nurses.Remove(Nurse);
                await _context.SaveChangesAsync();
            }
        }

    }
}
