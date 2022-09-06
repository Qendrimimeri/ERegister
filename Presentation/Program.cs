//using Application.Repository;
using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presentation;
using System;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<SuperAdminInitializer>();
builder.Services.AddDbContext<ERegisterDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.Configure<Admin>(builder.Configuration.GetSection(Admin.SectionName));

builder.Services.AddIdentity<AspNetUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ERegisterDBContext>()
    .AddSignInManager<SignInManager<AspNetUser>>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();


// Adding Repositories for depndency injections
//Repository Implementation 
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//var init = app.Services.CreateScope();
//new SuperAdminInitializer(init.ServiceProvider.GetService<ApplicationDbContext>()).Initialize();
app.Run();
