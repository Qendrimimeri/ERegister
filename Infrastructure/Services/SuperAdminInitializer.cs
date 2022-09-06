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

        public SuperAdminInitializer(ERegisterDBContext context) => Context = context;

        public ERegisterDBContext Context { get; }
        public Admin Admin { get; }

        public async void Initialize()
        {
            var roles = new List<string>() { "SuperAdmin", "MunicipalityAdmin", "LocalAdmin", "SimpleMember" };

            //foreach (var role in roles)
            //{
            //    if (!Context.Roles.Any(r => r.Name == role))
            //    {
            //        await new RoleStore<IdentityRole>(Context).CreateAsync(new IdentityRole()
            //        {
            //            Name = role,
            //            NormalizedName = role.ToUpper()
            //        });
            //    }
            //}

            Context.SaveChanges();

            var admin = new AspNetUser
            {
                FirstName = "Eregister",
                LastName = "Admin",
                Email = "admin@eregister.com",
                NormalizedEmail = "ADMIN@EREGISTER.COM",
                EmailConfirmed = true,
                UserName = "admin@eregister.com",
                NormalizedUserName = "ADMIN@EREGISTER.COM",
                CreatedAt = DateTime.Now,
                SocialNetwork = "http://www.facebook.com/eregister"
            };

            var userStore = new UserStore<AspNetUser>(Context);

            if (!Context.AspNetUsers.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<AspNetUser>().HashPassword(admin, "Eregister1");
                admin.PasswordHash = password;

                await userStore.CreateAsync(admin);
                await userStore.AddToRoleAsync(admin, roles[0]);
            }
            await Context.SaveChangesAsync();
        }
    }
}
