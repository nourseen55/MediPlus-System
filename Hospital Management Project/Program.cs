using Hospital_Management_Project.Middlewares;
using HospitalSystem.Application.IServices;
using HospitalSystem.Application.Services;
using HospitalSystem.Infrastructure.Mapping;
using HospitalSystem.Persistance.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("cs");
            var connectionstring2 = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
            var connectionstring3 = builder.Configuration.GetConnectionString("cs3");
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionstring3));

            var emalconfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            builder.Services.AddSingleton(emalconfig);

            // Identity configuration
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

                #region Password policy
                options.Password = new PasswordOptions
                {
                    RequiredLength = 8,
                    RequireDigit = false,
                    RequireUppercase = false,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false
                };
                #endregion
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Add a lifetime for the generated token
            builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1); // Token valid for 1 hour
            });

            builder.Services.AddRazorPages();

            #region AutoMapper configuration
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            #endregion

            #region Register application services
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<INurseService, NurseService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            #endregion

            #region Configure Cookie-based Authentication
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login"; // Redirect to login if not authenticated
                options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // Redirect if access is denied
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set session timeout
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            // Ensure authentication and authorization middleware are in the correct order
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            //This middleware is to make all the requests with Admin area to be checked for its Authorization
            //app.UseMiddleware<AreaAuthorizationMiddleware>();

            #region Map controller routes
            app.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
    }
}
