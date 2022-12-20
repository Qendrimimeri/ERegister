using Presentation.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.CustomIdentity();
builder.Services.OptionPattern();
builder.Services.CustomExtension();

builder.Services.CustomDataBase();

builder.Services.AddAutoMapper();

var loggerVar = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(loggerVar);

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseMigrationsEndPoint();
else
{
    app.UseHsts();
    app.UseDeveloperExceptionPage();
}
app.MiddleWareCustomPipline();

app.MapControllerRoute( name: "default", pattern: "{controller=Home}/{action=Index}/{id?}" );

var init = app.Services.CreateScope();
AdminExtension.Admin(init); 

app.Run();