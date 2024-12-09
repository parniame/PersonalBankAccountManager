using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Security.Claims;
using Abstraction.Domain;
using Persistence.Repositories;
using Persistence;
using Mapster;
using Service.ServiceInterfaces;
using Service.ServiceClasses;
using Service.Mapster;

using Microsoft.Extensions.Options;
using Abstraction.Service;
using Service;
using Hangfire;

namespace PersonalBankAccountManager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("PersonalBankAccountManagerDBContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineTicketAndReservationDbContextConnection' not found.");
            builder.Services.AddDbContext<DbContext, PersonalBankAccountManagerDBContext>();
            string HangFireConn = "Data Source=.;Initial Catalog=hangfiredb;TrustServerCertificate=True;Integrated Security=SSPI";
            //builder.Services.AddHangfire(x => x.UseSqlServerStorage(HangFireConn));
            //builder.Services.AddHangfireServer();
            builder.Services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<PersonalBankAccountManagerDBContext>().AddDefaultTokenProviders();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ClaimsPrincipal>();
            builder.Services.Configure<IdentityOptions>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequiredLength = 3;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;
                Options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
                
            });



            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            ServiceMapsterConfig.RegisterMapping();
            PresentationMapsterConfig.RegisterMapping();
            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();




            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Accounting/Login";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(3);
               

            });
            builder.Services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IBankService, BankService>();
            builder.Services.AddScoped<IBankAccountService, BankAccountService>();
            builder.Services.AddScoped<ITransactionCategoryService, TransactionCategoryService>();
            builder.Services.AddScoped<ITransactionPlanService, TransactionPlanService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<ITransactionCategoryService,TransactionCategoryService>();


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHangfireDashboard("/hangfire");


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoint.MapRazorPages();
            });
            using (var scope = app.Services.CreateScope())
            {
               
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                var roles = new[] { "Admin", "Member" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new Role(role));
                    }

                }


            }
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string userName = "Admin1";
                if( await userManager.FindByNameAsync(userName) ==  null) {
                    var user = new User();
                    user.UserName = userName;
                    user.FirstName = "Parnia";
                    user.LastName = "Minaee";
                    user.Email = "Minaeeparnia@gmail.com";
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user,"123");
                    await userManager.CreateAsync(user);
                    await userManager.AddToRoleAsync(user,"Admin");

                }

            }

            app.Run();
        }
    }
}
