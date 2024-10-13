using Microsoft.Identity.Client.Extensibility;
using System.Text;

namespace HospitalSystem.Persistance.Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        public DoctorRepository(ApplicationDbContext context,UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
        }
        public async Task AddEntityAsync(Doctor entity)
        {
            await _userStore.SetUserNameAsync(entity, entity.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(entity, entity.PasswordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, UserRoles.Doctor.ToString());

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(entity);

                var confirmResult = await _userManager.ConfirmEmailAsync(entity, token);

                if (confirmResult.Succeeded)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Doctor>> GetAllEntityAsync()
        {
            return await _context.Doctors.Include(p=>p.Department).ToListAsync();
        }

        public async Task<Doctor?> GetEntityByIdAsync(string id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Doctor entity)
        {
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(string id)
        {
            var Doctor = await GetEntityByIdAsync(id);
            if (Doctor != null)
            {
                _context.Doctors.Remove(Doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetByDepartmentId(string Id)
        {
            return await _context.Doctors.Where(x => x.DepartmentId == Id ).ToListAsync();

        }


    }
}
