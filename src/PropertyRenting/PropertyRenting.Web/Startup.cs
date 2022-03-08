using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PropertyRenting.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyRenting.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionInfo = GetConnectionStringAndAssemblyName();

            //builder.RegisterModule(new FoundationModule(connectionInfo.connectionString,
            //  connectionInfo.migrationAssemblyName))
            //    .RegisterModule(new WebModule())
            //    .RegisterModule(new EmailMessagingModule(connectionInfo.connectionString,
            //    connectionInfo.migrationAssemblyName))
            //    .RegisterModule(new MembershipModule(connectionInfo.connectionString,
            //    connectionInfo.migrationAssemblyName));
        }

        private (string connectionString, string migrationAssemblyName) GetConnectionStringAndAssemblyName()
        {
            var connectionStringName = "DevTeamDbConnection";
            var connectionString = Configuration.GetConnectionString(connectionStringName);
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            return (connectionString, migrationAssemblyName);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionInfo = GetConnectionStringAndAssemblyName();

            //services.AddDbContext<FoundationDbContext>(options =>
            //         options.UseSqlServer(connectionInfo.connectionString, b =>
            //         b.MigrationsAssembly(connectionInfo.migrationAssemblyName)));

            //services.AddDbContext<MembershipDbContext>(options =>
            //         options.UseSqlServer(connectionInfo.connectionString, b =>
            //         b.MigrationsAssembly(connectionInfo.migrationAssemblyName)));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionInfo.connectionString, b =>
                b.MigrationsAssembly(connectionInfo.migrationAssemblyName)));

            //services
            //    .AddIdentity<ApplicationUser, Role>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddUserManager<UserManager>()
            //    .AddRoleManager<RoleManager>()
            //    .AddSignInManager<SignInManager>()
            //    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                    opt.TokenLifespan = TimeSpan.FromHours(2));

            services.AddAuthentication()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                    options.Cookie.Name = "CustomerPortal.Identity";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("CompanyAdmin", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new CompanyAdminRequirement());
                //});

                //options.AddPolicy("SuperAdmin", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new SuperAdminRequirement());
                //});

                //options.AddPolicy("Manager", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new ManagerRequirement());
                //});

                //options.AddPolicy("Employee", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new EmployeeRequirement());
                //});

                //options.AddPolicy("Contractor", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new ContractorRequirement());
                //});

                //options.AddPolicy("CommonPermission", policy =>
                //{
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new CommonPermissionRequirement());
                //});
            });

            //services.AddSingleton<SuperAdminDataSeed>();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            //services.AddSingleton<IAuthorizationHandler, CommonPermissionRequirementHandler>();
            //services.AddSingleton<IAuthorizationHandler, CompanyAdminRequirementHandler>();
            //services.AddSingleton<IAuthorizationHandler, ContractorRequirementHandler>();
            //services.AddSingleton<IAuthorizationHandler, EmployeeRequirementHandler>();
            //services.AddSingleton<IAuthorizationHandler, ManagerRequirementHandler>();
            //services.AddSingleton<IAuthorizationHandler, SuperAdminRequirementHandler>();
            //services.Configure<PathSettings>(Configuration.GetSection("Paths"));
            //services.Configure<SmtpConfiguration>(Configuration.GetSection("Smtp"));
            //services.Configure<ReCaptchaKey>(Configuration.GetSection("ReCAPTCHASettings"));
            //services.Configure<DefaultSiteSettings>(Configuration.GetSection("DefaultSiteSettings"));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            //superAdminDataSeed.SeedUserAsync().Wait();
        }
    }
}
