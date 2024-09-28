using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Infrastructure.Mapping;
namespace Hospital_Management_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options=>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            );


            builder.Services.AddRazorPages();

            #region Identity Configuration
            builder.Services.AddIdentity<IdentityUser,IdentityRole>(options =>
            {
                /*options.SignIn.RequireConfirmedAccount = true;
                options.Password = new()
                {
                    RequiredLength = 8,
                    RequiredUniqueChars = 0,
                    RequireDigit = true,
                    RequireUppercase = true,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true
                };*/
            }).AddDefaultTokenProviders()
              .AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IAppointmentService,AppointmentService>(); 

            builder.Services.AddScoped<IDoctorService,DoctorService>();
            builder.Services.AddScoped<IImageService,ImageService>();
            


            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.MapRazorPages();
            app.UseAuthorization();



            app.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
