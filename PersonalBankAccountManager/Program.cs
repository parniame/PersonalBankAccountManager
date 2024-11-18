using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Security.Claims;
using Abstraction.Domain;
using Persistence.Repositories;
using Persistence;
using Mapster;
namespace PersonalBankAccountManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("OnlineTicketAndReservationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'OnlineTicketAndReservationDbContextConnection' not found.");
            builder.Services.AddDbContext<DbContext, PersonalBankAccountManagerDBContext>();

            builder.Services.AddIdentity<User, Role>(Options => {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequiredLength = 3;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<PersonalBankAccountManagerDBContext>().AddDefaultTokenProviders();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ClaimsPrincipal>();
            builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);



            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            //MapsterConfig.RegisterMapping();
            builder.Services.AddMvc();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();




            builder.Services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Identity/Account/Login";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(3);

            });


            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //builder.Services.AddScoped<IUserService, UserService>();
            //builder.Services.AddScoped<IRoleService, RoleService>();
            //builder.Services.AddScoped<ICategoryService, CategoryService>();
            //builder.Services.AddScoped<ITicketService, TicketService>();
            //builder.Services.AddScoped<IProvinceService, ProvinceService>();
            //builder.Services.AddScoped<IResidenceService, ResidenceService>();
            //builder.Services.AddScoped<ITransportationDeviceService, TransportationDeviceService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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

            app.Run();
        }
    }
}
