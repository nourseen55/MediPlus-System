using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalSystem.Infrastructure.Configurations
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
        }
    }
}
