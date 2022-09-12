using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Microsoft.Extensions.Options;
using Domain.Data;
using Domain.Data.Entities;

namespace Infrastructure.Services
{
    public class SuperAdminInitializer
    {



        //public SuperAdminInitializer(IOptionsSnapshot<Admin> admin) => Admin = admin.Value;

        public SuperAdminInitializer(ApplicationDbContext context) => Context = context;

        public ApplicationDbContext Context { get; }
        public Admin Admin { get; }

        public async void Initialize()
        {
            var roles = new List<string>() { "SuperAdmin", "MunicipalityAdmin", "LocalAdmin", "SimpleMember", "SimpleRole" };

            foreach (var role in roles)
            {
                if (!Context.Roles.Any(r => r.Name == role))
                {
                    await new RoleStore<IdentityRole>(Context).CreateAsync(new IdentityRole()
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });
                }
            }

            Context.SaveChanges();

            var admin = new ApplicationUser
            {
                FullName = "Admin",
                Email = "admin@eregister.com",
                NormalizedEmail = "ADMIN@EREGISTER.COM",
                EmailConfirmed = true,
                UserName = "admin@eregister.com",
                NormalizedUserName = "ADMIN@EREGISTER.COM",
                CreatedAt = DateTime.Now,
                SocialNetwork = "http://www.facebook.com/eregister",
                WorkId = "5355f324-fa20-4bbe-900d-b16c925dd890",
                AddressId = "e2a1b84a-f828-408e-b130-c61abce41111",
                ActualStatus = "Ne Process"
            };

            var userstore = new UserStore<ApplicationUser>(Context);

            if (!Context.ApplicationUsers.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Eregister1");
                admin.PasswordHash = password;

                await userstore.CreateAsync(admin);
                await userstore.AddToRoleAsync(admin, roles[0]);
            }
            await Context.SaveChangesAsync();
        }
    }
}
