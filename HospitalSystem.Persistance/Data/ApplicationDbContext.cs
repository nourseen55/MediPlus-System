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

            //SeedRoles(modelBuilder);
        }


        //private void SeedRoles(ModelBuilder modelBuilder)
        //{
        //    foreach(var role in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        int c = 1;
        //        string? StringRole = role.ToString();
        //        if(StringRole is null)
        //            continue;
        //        modelBuilder.Entity<IdentityRole>().HasData(

        //            new IdentityRole
        //            {
        //                Id = $"{c}",
        //                Name = StringRole,
        //                NormalizedName = StringRole.ToUpper()
        //            }
        //        );}
          
        
    }
}
