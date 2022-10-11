using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appliaction.Models;
using Microsoft.Extensions.Options;
using Domain.Data;
using Domain.Data.Entities;
using Application.Models;

namespace Infrastructure.Services
{
    public class SuperAdminInitializer
    {
        private readonly Admin _admin;
        private readonly ApplicationDbContext _context;
        private readonly AppRoles _roles;

        public SuperAdminInitializer(ApplicationDbContext context,
                                    IOptionsSnapshot<Admin> admin,
                                    IOptionsSnapshot<AppRoles> roles)
        {
            _context = context;
            _roles = roles.Value;
            _admin = admin.Value;
        }

        public ApplicationDbContext Context { get; }

        public async void Initialize()
        {
            var roles = new List<string>() { "KryetarIPartise", "KryetarIKomunes","KryetarIFshatit","AnetarIThjeshte", "SimpleRole" };

            foreach (var role in roles)
            {
                if (!_context.Roles.Any(r => r.Name == role))
                {
                    await new RoleStore<IdentityRole>(Context).CreateAsync(new IdentityRole()
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });
                }
            }

            _context.SaveChanges();

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
                AddressId = "18cd24f9-e8f2-4bff-89e7-4864860454aa",

                ActualStatus = "Ne Process"
            };

            var userstore = new UserStore<ApplicationUser>(_context);

            if (!_context.ApplicationUsers.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Eregister1");
                admin.PasswordHash = password;

                await userstore.CreateAsync(admin);
                await userstore.AddToRoleAsync(admin, roles[0]);
            }
            await _context.SaveChangesAsync();
        }
    }
}
