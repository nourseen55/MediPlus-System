
namespace HospitalSystem.Infrastructure.Repository
{
    public class AppointmentRepository : IRepository<Appointment>
    {

        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddEntityAsync(Appointment entity)
        {
            _context.Appointments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllEntityAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> GetEntityByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Appointment entity)
        {
            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(int id)
        {
            var Appointment = await GetEntityByIdAsync(id);
            if (Appointment != null)
            {
                _context.Appointments.Remove(Appointment);
                await _context.SaveChangesAsync();
            }
        }

    }
}
