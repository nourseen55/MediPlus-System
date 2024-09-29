namespace HospitalSystem.Persistance.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder
                 .HasOne(d => d.Department)          
                 .WithMany(dep => dep.Doctors)        
                 .HasForeignKey(d => d.DepartmentId)  
                 .OnDelete(DeleteBehavior.Restrict);  

        }
    }
}
