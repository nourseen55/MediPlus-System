using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HospitalSystem.Infrastructure.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUser");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ZipCode).HasMaxLength(5);
            builder.Property(e=>e.City).HasMaxLength(20);



        }
    }
}
