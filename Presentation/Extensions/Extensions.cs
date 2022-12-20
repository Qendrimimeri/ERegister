using Application.Models.Services;
using Domain.Data.Entities;
using Domain.Data;
using Microsoft.AspNetCore.Identity;
using AppDomain = Application.Models.Services.AppDomain;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Application.Repository;
using Application.Repository.IRepository;
using Presentation.AutoMapper;

namespace Presentation.Extensions;

public static class OptionPatterns
{

    public static IServiceCollection OptionPattern(this IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        services.Configure<ActualStatus>(builder.Configuration.GetSection(ActualStatus.SectionName));
        services.Configure<Admin>(builder.Configuration.GetSection(Admin.SectionName));
        services.Configure<AdministrativeUnits>(builder.Configuration.GetSection(AdministrativeUnits.SectionName));
        services.Configure<AppDomain>(builder.Configuration.GetSection(AppDomain.SectionName));
        services.Configure<ExceptionHandler>(builder.Configuration.GetSection(ExceptionHandler.SectionName));
        services.Configure<Demands>(builder.Configuration.GetSection(Demands.SectionName));
        services.Configure<Reasons>(builder.Configuration.GetSection(Reasons.SectionName));
        services.Configure<Roles>(builder.Configuration.GetSection(Roles.SectionName));
        services.Configure<SuccessChances>(builder.Configuration.GetSection(SuccessChances.SectionName));
        services.Configure<Toaster>(builder.Configuration.GetSection(Toaster.SectionName));
        services.Configure<YesNo>(builder.Configuration.GetSection(YesNo.SectionName));
        services.Configure<Encrypt>(builder.Configuration.GetSection(Encrypt.SectionName));
        services.Configure<Admin>(builder.Configuration.GetSection(Admin.SectionName));
        services.Configure<Mail>(builder.Configuration.GetSection(Mail.SectionName));

        return services;
    }

}



public static class Identity
{
    public static IServiceCollection CustomIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase= false;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultTokenProviders();
        return services;
    }
}


public static class DataBase
{
    public static IServiceCollection CustomDataBase(this IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        if (!builder.Environment.IsDevelopment())
        {
            var  sqlServer = builder.Configuration.GetConnectionString("sqlServer");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlServer), ServiceLifetime.Transient);
        }
        var localConnection = builder.Configuration.GetConnectionString("localConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(localConnection), ServiceLifetime.Transient);

        var connectionString = builder.Configuration.GetConnectionString("Dev");
        //services.AddDbContext<ApplicationDbContext>(
        //    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
        //                        ServiceLifetime.Transient);
        return services;


    }
}

public static class AutoMapper
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        services.AddAutoMapper(typeof(ApplicationMapper));
        return services;
    }
}

public static class Custom
{
    public static IServiceCollection CustomExtension(this IServiceCollection services)
    {
        services.AddTransient<SuperAdminInitializer>();
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddTransient<IMailService, MailService>();
        services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
