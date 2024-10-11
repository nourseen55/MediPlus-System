using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Persistance.Configurations
{
    public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
    {
        public void Configure(EntityTypeBuilder<WorkingHours> builder)
        {

            builder.ToTable("WorkingHours");
                builder
                .HasOne(w => w.Doctor) // Each WorkingHours has one Doctor
                .WithMany(d => d.WorkingHours) // Doctor has many WorkingHours
                .HasForeignKey(w => w.DoctorId) // Foreign key in WorkingHours
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
