namespace HospitalSystem.Persistance.Configurations
{
    internal class NurseConfiguration : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.ToTable("Nurse");

            builder
          .HasOne(n => n.Doctor)
          .WithMany(d => d.Nurses)
          .HasForeignKey(n => n.DoctorID)
          .OnDelete(DeleteBehavior.Restrict);

            builder
        .HasOne(n => n.Departments)
        .WithMany(d => d.Nurses)
        .HasForeignKey(n => n.DepartmentID)
        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
