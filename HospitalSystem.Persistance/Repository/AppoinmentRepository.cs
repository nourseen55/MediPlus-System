
namespace HospitalSystem.Persistance.Repository
{
    public class AppointmentRepository : IAppointmentRepository
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
            return await _context.Appointments.Include(a=>a.Patient).Include(b=>b.Doctor).ToListAsync();
        }

        public async Task<Appointment?> GetEntityByIdAsync(string id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Appointment entity)
        {
            _context.Appointments.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(string id)
        {
            var Appointment = await GetEntityByIdAsync(id);
            if (Appointment != null)
            {
                _context.Appointments.Remove(Appointment);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Patient>> GetPatientsByDoctorAsync(string doctorId)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorID == doctorId && a.Patient != null)
                .Select(a => a.Patient)
                .Distinct()
                .ToListAsync();
        }
    }
}
