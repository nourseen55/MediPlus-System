namespace HospitalSystem.Persistance.Repository
{
    public class EducationRepository : IGenericRepository<Education>
    {
        private readonly ApplicationDbContext _context;
        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(Education entity)
        {
            _context.Educations.Add(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteEntityAsync(string id)
        {
            var education = await GetEntityByIdAsync(id);
            if (education != null)
            {
                _context.Educations.Remove(education);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Education>> GetAllEntityAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<Education?> GetEntityByIdAsync(string id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Education entity)
        {

            _context.Educations.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
