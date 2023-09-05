using APIAdoPet.Domains;
using APIAdoPet.Infraestrutura.Data;
using APIAdoPet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789áéíóúàèìòùâêîôûãõç";
        });
    }
    public static void AdicionarAuthentication(this IServiceCollection services)
    {
         services.AddAuthentication(opts =>
         {
             opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

         }).AddJwtBearer(opts =>
         {
             opts.RequireHttpsMetadata = false;
             opts.SaveToken = true;
             opts.TokenValidationParameters = new TokenValidationParameters
             {

                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey
                   (Encoding.UTF8.GetBytes("vmçOJDhvPOSEIhvPSOIjkhfnP")),
                 ValidateIssuer = false,
                 ValidateAudience = false,
             };
         });
        services.AddControllers(opt =>
        {
            var policy = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });
    }





}
