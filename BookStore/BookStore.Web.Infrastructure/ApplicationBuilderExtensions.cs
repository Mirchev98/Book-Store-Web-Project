using BookStore.Common;
using BookStore.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app, string email) 
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task
                .Run(async () =>
                {
                    if(await roleManager.RoleExistsAsync(DataConstants.AdminRoleName)) 
                    {
                        return;
                    }

                    var role = new IdentityRole<Guid> { Name = DataConstants.AdminRoleName };

                    await roleManager.CreateAsync(role);

                    ApplicationUser adminUser = await userManager.FindByEmailAsync(email);

                    await userManager.AddToRoleAsync(adminUser, DataConstants.AdminRoleName);
                }
                )
                .GetAwaiter()
                .GetResult();

            return app;
        }

    }
}
