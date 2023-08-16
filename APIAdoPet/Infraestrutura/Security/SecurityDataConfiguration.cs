using APIAdoPet.Domains;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Options;

namespace APIAdoPet.Infraestrutura.Security;

public static class SecurityDataConfiguration
{
    public static void AddDataSecurity(this IServiceCollection services)
    {
        services.AddIdentity<Usuario, IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<APIAdopetContext>()
            .AddDefaultTokenProviders();
    }

    public static void ConfigurationOfPassword(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(opts =>
        {
            opts.Password.RequiredLength = 4;
            opts.Password.RequireDigit = true;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireNonAlphanumeric = false;
            opts.Password.RequireUppercase = false;
            opts.User.RequireUniqueEmail = true;
            opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        });
    } 

    



}
