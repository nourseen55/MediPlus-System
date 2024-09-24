namespace HospitalSystem.Persistance.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUser");
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.ZipCode).HasMaxLength(5);
            builder.Property(e=>e.City).HasMaxLength(20);
            builder.Property(e => e.Gender)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (Gender)Enum.Parse(typeof(Gender), v))
                .HasMaxLength(1)  
                .IsUnicode(false);
        }
    }
}
