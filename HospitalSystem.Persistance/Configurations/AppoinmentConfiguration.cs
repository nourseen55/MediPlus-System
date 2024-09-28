namespace HospitalSystem.Persistance.Configurations
{
    internal class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable(nameof(Appointment));
            builder.HasKey(a => a.AppointmentID);
            builder.Property(a => a.Status).IsRequired();
            builder
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.Restrict);
            builder
             .HasOne(a => a.Doctor)
             .WithMany(d => d.Appointments)
             .HasForeignKey(a => a.DoctorID)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}