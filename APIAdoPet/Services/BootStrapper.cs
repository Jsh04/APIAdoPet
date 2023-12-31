﻿using APIAdoPet.Services.Interfaces;

namespace APIAdoPet.Services;

public static class BootStrapper
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddServicesClasses(services);
    }

    static void AddServicesClasses(IServiceCollection services)
    {
        services.AddScoped<IAdocaoService, AdocaoService>();
        services.AddScoped<ITutorService, TutorService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped <ITokenService, TokenService>();
        services.AddScoped<IAbrigoService, AbrigoService>();
        services.AddScoped<IPetService, PetService>();
    }
}
