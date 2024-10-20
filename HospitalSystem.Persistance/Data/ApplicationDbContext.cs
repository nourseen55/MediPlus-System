using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HospitalSystem.Persistance.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
       /* public ApplicationDbContext()
        {

        }*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalRecordConfiguration());
            modelBuilder.ApplyConfiguration(new NurseConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingHoursConfiguration());

            var roles = SeedRoles(modelBuilder);
            SeedUser(modelBuilder,roles);
        }

        private Dictionary<string, string> SeedRoles(ModelBuilder modelBuilder)
        {
            var roleIds = new Dictionary<string, string>();

            foreach (var role in Enum.GetValues(typeof(UserRoles)))
            {
                string roleName = role.ToString();
                if (roleName == null) { continue; }

                var roleId = Guid.NewGuid().ToString();
                roleIds[roleName] = roleId;

                modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = roleId,
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    }
                );
            }

            return roleIds;
        }

        private void SeedUser(ModelBuilder modelBuilder, Dictionary<string, string> roleIds)
        {
            var adminId = Guid.NewGuid().ToString();

            var adminUser = new ApplicationUser
            {
                Id = adminId,
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin@11"),
                FirstName = "Admin",
                LastName = "User", 
                Img = null,
                ZipCode = null,
                Country = null,
                City = null,
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2003, 12, 20)
            };

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleIds["Admin"],
                UserId = adminId
            });
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=HosiptalDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }*/
    }
}
