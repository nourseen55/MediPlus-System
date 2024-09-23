using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
