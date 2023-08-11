using APIAdoPet.Domains;
using APIAdoPet.Infraestrutura.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace APIAdoPet.Infraestrutura.Security;

public static class SecurityDataConfiguration
{
    public static void AddDataSecurity(this IServiceCollection services)
    {
        services.AddIdentity<Usuario, IdentityRole>()
            .AddEntityFrameworkStores<APIAdopetContext>()
            .AddDefaultTokenProviders();
    }

}
