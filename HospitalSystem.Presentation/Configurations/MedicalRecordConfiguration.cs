namespace HospitalSystem.Persistance.Configurations
{
    internal class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.ToTable("MedicalRecord");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Diagnosis).IsRequired();
            builder.Property(x=>x.Treatment).IsRequired();
            builder
            .HasOne(m => m.Patient)
            .WithMany(p => p.MedicalRecords)
            .HasForeignKey(m => m.PatientID)
            .OnDelete(DeleteBehavior.Restrict);

           builder
                .HasOne(m => m.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(m => m.DoctorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
