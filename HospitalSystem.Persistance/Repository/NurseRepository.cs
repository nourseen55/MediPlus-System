
using Microsoft.AspNetCore.Identity;

namespace HospitalSystem.Persistance.Repository
{
    public class NurseRepository : IGenericRepository<Nurse>
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        public NurseRepository(ApplicationDbContext context,UserManager<ApplicationUser> userManager, IUserStore<ApplicationUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
        }

        public async Task AddEntityAsync(Nurse entity)
        {
            await _userStore.SetUserNameAsync(entity, entity.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(entity, entity.PasswordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(entity, UserRoles.Nurse.ToString());

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(entity);

                var confirmResult = await _userManager.ConfirmEmailAsync(entity, token);

                if (confirmResult.Succeeded)
                {
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task<IEnumerable<Nurse>> GetAllEntityAsync()
        {
            return await _context.Nurses.Include(d=>d.Doctor).Include(x=>x.Departments).ToListAsync();
        }

        public async Task<Nurse?> GetEntityByIdAsync(string id)
        {
            return await _context.Nurses.FindAsync(id);
        }

        public async Task UpdateEntityAsync(Nurse entity)
        {
            _context.Nurses.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(string id)
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
