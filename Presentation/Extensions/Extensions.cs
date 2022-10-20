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
        services.Configure<GeneralDemands>(builder.Configuration.GetSection(GeneralDemands.SectionName));
        services.Configure<GeneralReasons>(builder.Configuration.GetSection(GeneralReasons.SectionName));
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
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;

        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddDefaultTokenProviders();
        return services;
    }
}


public static class Logger
{
    public static ILoggingBuilder CustomLogger(this ILoggingBuilder logger)
    {
        var builder = WebApplication.CreateBuilder();
        var loggerVar = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(loggerVar);
        return logger;
    }
}

public static class DataBase
{
    public static IServiceCollection CustomDataBase(this IServiceCollection services)
    {
        var builder = WebApplication.CreateBuilder();
        var connectionString = builder.Configuration.GetConnectionString("Dev");
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                                ServiceLifetime.Transient);
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
