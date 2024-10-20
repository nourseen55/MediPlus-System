namespace HospitalSystem.Persistance.Repository
{
    public class WorkingHoursRepository : IGenericRepository<WorkingHours>
    {
        private readonly ApplicationDbContext _context;
        public WorkingHoursRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       
		public async Task AddEntityAsync(WorkingHours entity)
		{
			_context.WorkingHours.Add(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<WorkingHours>> GetAllEntityAsync()
		{
			return await _context.WorkingHours.ToListAsync();
		}
		public async Task<WorkingHours?> GetEntityByIdAsync(string id)
		{
			return await _context.WorkingHours.FindAsync(id);
		}

        public async Task UpdateEntityAsync(WorkingHours entity)
        {
            _context.WorkingHours.Attach(entity);
            _context.Entry(entity).Property(e => e.Day).IsModified = true;
            _context.Entry(entity).Property(e => e.StartHour).IsModified = true;
            _context.Entry(entity).Property(e => e.EndHour).IsModified = true;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteEntityAsync(string id)
		{
			var hours = await GetEntityByIdAsync(id);
			if (hours != null)
			{
				_context.WorkingHours.Remove(hours);
				await _context.SaveChangesAsync();
			}
		}

		
	
	}
}
