using BitirmeProjesi.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.WebUI
{
    public class SeedIdentity
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"]; // appsettings.json dan bilgi almak için kullanılır 
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if (await userManager.FindByNameAsync(username) == null) // böyle bir kullanıcı adı var mı diye sorduk 
            {
                await roleManager.CreateAsync(new IdentityRole(role)); // rol oluşturduk

                var user = new User()
                { // kullanıcı bilgilerini girdik

                    UserName = username,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "Admin"
                    

                };

                var result = await userManager.CreateAsync(user, password); // kullanıcı oluşturduk
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role); // kullanıcıya rolü ekledik
                }
            }
        }
    }
}
