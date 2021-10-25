using System;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Service.Service;
using Service.Service.User;

namespace CrossCuting.DependencyInjection
{
    public static class ConfigureService
    {
          public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAnuncioService, AnuncioService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();

        }
    }
}
