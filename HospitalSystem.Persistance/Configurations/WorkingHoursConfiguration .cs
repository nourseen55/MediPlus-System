using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Persistance.Configurations
{
    public class WorkingHoursConfiguration : IEntityTypeConfiguration<WorkingHours>
    {
        public void Configure(EntityTypeBuilder<WorkingHours> builder)
        {

            builder.ToTable("WorkingHours");
                builder
                .HasOne(w => w.Doctor)
                .WithMany(d => d.WorkingHours) 
                .HasForeignKey(w => w.DoctorId) 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
