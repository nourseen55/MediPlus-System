namespace HospitalSystem.Persistance.Repository
{
    public class MedicalRecordRepository : IGenericRepository<MedicalRecord>
    {

        private readonly ApplicationDbContext _context;

        public MedicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(MedicalRecord entity)
        {
            _context.MedicalRecords.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MedicalRecord>> GetAllEntityAsync()
        {
            return await _context.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord?> GetEntityByIdAsync(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        public async Task UpdateEntityAsync(MedicalRecord entity)
        {
            _context.MedicalRecords.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var MedicalRecord = await GetEntityByIdAsync(id);
            if (MedicalRecord != null)
            {
                _context.MedicalRecords.Remove(MedicalRecord);
                await _context.SaveChangesAsync();
            }
        }

    }
}
