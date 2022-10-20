using Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.CustomIdentity();
builder.Services.OptionPattern();
builder.Logging.CustomLogger();
builder.Services.CustomExtension();
builder.Services.CustomDataBase();
var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseMigrationsEndPoint();
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.MiddleWareCustomPipline();
app.MapControllerRoute( name: "default", pattern: "{controller=Home}/{action=Index}/{id?}" );
var init = app.Services.CreateScope();
AdminExtension.Admin(init); 
app.Run();