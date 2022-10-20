using Application.Repository;
using Domain.Data;
using Domain.Data.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.Extensions.Options;
using Application.Models.Services;
using AppDomain = Application.Models.Services.AppDomain;
using Application.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Dev");


builder.Services.AddTransient<SuperAdminInitializer>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.Configure<Admin>(builder.Configuration.GetSection(Admin.SectionName));
builder.Services.Configure<Mail>(builder.Configuration.GetSection(Mail.SectionName));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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


builder.Services.Configure<ActualStatus>(builder.Configuration.GetSection(ActualStatus.SectionName));
builder.Services.Configure<Admin>(builder.Configuration.GetSection(Admin.SectionName));
builder.Services.Configure<AdministrativeUnits>(builder.Configuration.GetSection(AdministrativeUnits.SectionName));
builder.Services.Configure<AppDomain>(builder.Configuration.GetSection(AppDomain.SectionName));
builder.Services.Configure<ExceptionHandler>(builder.Configuration.GetSection(ExceptionHandler.SectionName));
builder.Services.Configure<GeneralDemands>(builder.Configuration.GetSection(GeneralDemands.SectionName));
builder.Services.Configure<GeneralReasons>(builder.Configuration.GetSection(GeneralReasons.SectionName));
builder.Services.Configure<Roles>(builder.Configuration.GetSection(Roles.SectionName));
builder.Services.Configure<SuccessChances>(builder.Configuration.GetSection(SuccessChances.SectionName));
builder.Services.Configure<Toaster>(builder.Configuration.GetSection(Toaster.SectionName));
builder.Services.Configure<YesNo>(builder.Configuration.GetSection(YesNo.SectionName));
builder.Services.Configure<Encrypt>(builder.Configuration.GetSection(Encrypt.SectionName));


var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
                                ServiceLifetime.Transient);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorHandler/Error/{0}");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var init = app.Services.CreateScope();
new SuperAdminInitializer(init.ServiceProvider.GetService<ApplicationDbContext>(),
                          init.ServiceProvider.GetService<IOptionsSnapshot<Admin>>(),
                          init.ServiceProvider.GetService<IOptionsSnapshot<Roles>>(),
                          init.ServiceProvider.GetService<IOptionsSnapshot<Encrypt>>()).Initialize();
app.Run();