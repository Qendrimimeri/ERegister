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
                WorkId = "c04ad72d-f47e-411d-a483-6907ca2582a0",
                AddressId = "f22643af-9cfd-4c42-9f5d-19cbaabfc660",
                ActualStatus = "Ne Process"
            };

            //var userstore = new userstore<applicationuser>(context);

            //if (!context.applicationusers.any(u => u.username == admin.username))
            //{
            //    var password = new passwordhasher<applicationuser>().hashpassword(admin, "eregister1");
            //    admin.passwordhash = password;

            //    await userstore.createasync(admin);
            //    await userstore.addtoroleasync(admin, roles[0]);
            //}
            await Context.SaveChangesAsync();
        }
    }
}
