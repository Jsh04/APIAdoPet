
using APIAdoPet.Exception.Filters;
using APIAdoPet.Infraestrutura;
using APIAdoPet.Infraestrutura.Security;
using APIAdoPet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AdicionarInfraestrutura(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

builder.Services.AdicionarAuthentication();
builder.Services.AddDataSecurity();
//builder.Services.AdicionarAuthorization();
//builder.Services.AdicionarAuthentication(); 
builder.Services.ConfigurationOfPassword();
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/error");
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
