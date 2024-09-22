using HospitalSystem.Application.Services;
using HospitalSystem.Core.UnitOfWork;
using HospitalSystem.Infrastructure.Context;
using HospitalSystem.Infrastructure.IRepository;
using HospitalSystem.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
