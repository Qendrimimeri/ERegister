﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Domain.Data;
using Domain.Data.Entities;
using Application.Models.Services;
using Application.Repository;

namespace Infrastructure.Services;


#pragma warning disable CS8604

public class SuperAdminInitializer
{
    private readonly Admin _admin;
    private readonly ApplicationDbContext _context;
    private readonly Encrypt _encrypt;
    private readonly Roles _roles;

    public SuperAdminInitializer(ApplicationDbContext context,
                                IOptionsSnapshot<Admin> admin,
                                IOptionsSnapshot<Roles> roles,
                                IOptionsSnapshot<Encrypt> encrypt)
    {
        _context = context;
        _encrypt = encrypt.Value;
        _roles = roles.Value;
        _admin = admin.Value;
    }


    public async void Initialize()
    {
        EncryptionService encrypt = new (_encrypt);
        var roles = new List<string>()
            {   _roles.KryetarIPartise,
                _roles.KryetarIKomunes,
                _roles.KryetarIFshatit,
                _roles.AnetarIThjeshte,
            };

        foreach (var role in roles)
        {
            if (!_context.Roles.Any(r => r.Name == role))
            {
                await new RoleStore<IdentityRole>(_context).CreateAsync(new IdentityRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                });
            }
        }
        _context.SaveChanges();

        var admin = new ApplicationUser
        {
            FullName = _admin.FirstName,
            Email = _admin.Email,
            NormalizedEmail = _admin.Email.ToUpper(),
            EmailConfirmed = true,
            UserName = _admin.Email,
            NormalizedUserName = _admin.Email.ToUpper(),
            CreatedAt = DateTime.Now,
            SocialNetwork = "http://www.facebook.com/eregister",
            AddressId = "18cd24f9-e8f2-4bff-89e7-4864860454aa",
            PhoneNumber = encrypt.Encrypt("213123123")

        };
        var userstore = new UserStore<ApplicationUser>(_context);
        if (!_context.ApplicationUsers.Any(u => u.UserName == admin.UserName))
        {
            var password = new PasswordHasher<ApplicationUser>().HashPassword(admin, _admin.Password);
            admin.PasswordHash = password;
            await userstore.CreateAsync(admin);
            await userstore.AddToRoleAsync(admin, roles[0]);
        }
        await _context.SaveChangesAsync();
    }
}

#pragma warning restore CS8604