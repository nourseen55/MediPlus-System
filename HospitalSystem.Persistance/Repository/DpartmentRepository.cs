namespace HospitalSystem.Persistance.Repository
{
    public class DpartmentRepository : IGenericRepository<Departments>
    {
        private readonly ApplicationDbContext _context;
        public DpartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEntityAsync(Departments entity)
        {
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Departments>> GetAllEntityAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Departments?> GetEntityByIdAsync(string id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Departments entity)
        {
            _context.Departments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(string id)
        {
            var Department = await GetEntityByIdAsync(id);
            if (Department != null)
            {
                _context.Departments.Remove(Department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
