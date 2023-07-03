using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace APIAdoPet.Infraestrutura;

public static class Bootstrapper
{
    public static void AdicionarInfraestrutura(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("APIAdopetConnection");

        services.AddDbContext<APIAdopetContext>(opts =>
        {
            opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            AddRepository(services);
        });

    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<ITutorRepository, TutorRepository>();
        services.AddScoped<IAbrigoRepository, AbrigoRepository>();
    }
}
