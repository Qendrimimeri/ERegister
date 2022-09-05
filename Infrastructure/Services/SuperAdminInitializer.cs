using Domain.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERegister.Data;
using Infrastructure.Models;

namespace Infrastructure.Services
{
    public class SuperAdminInitializer
    {
        //public SuperAdminInitializer(Admin admin) => Admin = admin;
        public SuperAdminInitializer(ApplicationDbContext context) => Context = context;

        public ApplicationDbContext Context { get; }
        public Admin Admin { get; }

        public async void Initialize()
        {
            var roles = new List<string>() { "SuperAdmin", "MunicipalityAdmin", "LocalAdmin", "SimpleMember" };

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
                FirstName = Admin.FirstName,
                LastName = "Admin",
                Email = Admin.Email,
                NormalizedEmail = "ADMIN@EREGISTER.COM",
                EmailConfirmed = true,
                Address = null,
                UserName = Admin.UserName,
                NormalizedUserName = "ADMIN@EREGISTER.COM",
                Work = null,
                CreatedAt = DateTime.Now,
                ActualStatus = null,
                SocialNetwork = "http://www.facebook.com/eregister"
            };

            var userStore = new UserStore<ApplicationUser>(Context);

            if (!Context.Users.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>().HashPassword(admin, Admin.Password);
                admin.PasswordHash = password;

                await userStore.CreateAsync(admin);
                await userStore.AddToRoleAsync(admin, roles[0]);
            }
            await Context.SaveChangesAsync();
        }
    }
}
