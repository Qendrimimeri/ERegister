using Application.Models.Services;
using Domain.Data;
using Infrastructure.Services;
using Microsoft.Extensions.Options;

namespace Presentation.Extensions;

public class AdminExtension
{
    public static void Admin(IServiceScope init)
    {
        new SuperAdminInitializer(init.ServiceProvider.GetService<ApplicationDbContext>(),
                                  init.ServiceProvider.GetService<IOptionsSnapshot<Admin>>(),
                                  init.ServiceProvider.GetService<IOptionsSnapshot<Roles>>(),
                                  init.ServiceProvider.GetService<IOptionsSnapshot<Encrypt>>()).Initialize();
    }
}
