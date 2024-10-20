namespace Hospital_Management_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("cs");
            //var connectionstring2 = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
            //var connectionstring3 = builder.Configuration.GetConnectionString("cs3");
            var emalconfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            var stripe = builder.Configuration.GetSection("Stripe");
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            #region Stripe
            builder.Services.Configure<StripeSettings>(stripe);
            #endregion
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
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddScoped<IWorkingHourstService, WorkingHoursService>();
            builder.Services.AddScoped<IEducationService, EducationService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.AddScoped<DoctorService>();
            builder.Services.AddSingleton(emalconfig);
            #endregion

            #region Configure Cookie-based Authentication
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login"; // Redirect to login if not authenticated
                options.AccessDeniedPath = "/Error/403"; // Redirect if access is denied
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Set session timeout

            });
            #endregion


            #region External Authentication
            //builder.Services.AddAuthentication()
            //    .AddGoogle(options =>
            //    {
            //        var googleSection = builder.Configuration.GetSection("Authentication:Google");
            //        options.ClientId = googleSection["ClientId"];
            //        options.ClientSecret = googleSection["ClientSecret"];
            //        options.CallbackPath = "/Identity/Account/Login/google";
            //        });
            //builder.Services.AddSession();
            #endregion


            var app = builder.Build();
            //app.UseSession();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }


            app.UseStaticFiles();
            app.UseRouting();
            StripeConfiguration.ApiKey = stripe["SecretKey"];
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