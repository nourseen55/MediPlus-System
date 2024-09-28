namespace HospitalSystem.Persistance.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
       /* public ApplicationDbContext()
        {

        }*/
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Patient> Patients { set;get; }
        public DbSet<Appointment> Appointments { set;get; }
        public DbSet<Doctor> Doctors { set;get; }
        public DbSet<MedicalRecord> MedicalRecords { set;get; }
        public DbSet<Nurse> Nurses { set;get; }
        public DbSet<Departments> Departments { set;get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalRecordConfiguration());
            modelBuilder.ApplyConfiguration(new NurseConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=HospitalDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        }
*/
    }
}
