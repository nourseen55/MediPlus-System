using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Persistance.Data;
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

            #region Identity Configuration
            builder.Services.AddDefaultIdentity<IdentityUser>(options =>
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
            }).AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion

            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            //builder.Services.AddScoped<IPatientService,PatientService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
