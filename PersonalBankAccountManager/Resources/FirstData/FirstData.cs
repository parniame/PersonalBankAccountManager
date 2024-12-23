using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace PersonalBankAccountManager.Resources.FirstData
{
    public static class FirstData
    {
        public static async Task  CreateRolesAsync(IServiceScope scope)
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
        public static async Task CreateAdmibAsync(IServiceScope scope)
        {
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            string userName = "Admin";
            if (await userManager.FindByNameAsync(userName) == null)
            {
                var user = new User();
                user.UserName = userName;
                user.FirstName = "Parnia";
                user.LastName = "Minaee";
                user.Email = "Minaeeparnia@gmail.com";
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "123");
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "Admin");

            }
            string userName2 = "Admin2";
            if (await userManager.FindByNameAsync(userName2) == null)
            {
                var user = new User();
                user.UserName = userName2;
                user.FirstName = "Ali";
                user.LastName = "AliZadeh";
                user.Email = "AliZadeh@gmail.com";
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, "123");
                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "Admin");

            }
        }
    }
}
