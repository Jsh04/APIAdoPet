using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Domains.Interfaces;
using APIAdoPet.Infraestrutura.Repository;
using Microsoft.EntityFrameworkCore;
namespace APIAdoPet.Infraestrutura;

public static class Bootstrapper
{
    public static void AdicionarInfraestrutura(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("APIAdopetConnection");

        services.AddDbContext<APIAdopetContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
       
        AddRepository(services);

    }

    static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IAbrigoRepository, AbrigoRepository>();
        services.AddScoped<ITutorRepository, TutorRepository>();
        services.AddScoped<IPetRepository,PetRepository>();
        services.AddScoped<IAdocaoRepository,AdocaoRepository>();
    }
}
