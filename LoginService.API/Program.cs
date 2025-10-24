using LoginService.Aplication.Interfaces.Login;
using LoginService.Aplication.Interfaces.Menu;
using LoginService.Aplication.Interfaces.Saml;
using LoginService.Aplication.UseCases.Login;
using LoginService.Aplication.UseCases.Saml.ObtenerInfo;
using LoginService.Infrastructure.Persistence.Log;
using LoginService.Infrastructure.Services.Login;
using LoginService.Infrastructure.Services.Menu;
using LoginService.Infrastructure.Services.Saml;
using MenuService.Aplication.Interfaces;
using MenuService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Utilities.Conexion;
using Utilities.Entities.Token;

var builder = WebApplication.CreateBuilder(args);

/*******************************************************/

// base de datos
builder.Services.AddDbContext<LoginAccesoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrdenesTrabajoConnection")));
builder.Services.AddDbContext<MenuDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrdenesTrabajoConnection")));
// Asegúrate de que "MenuConnection" sea la cadena de conexión correcta para la base de datos de menú.
// Registrar el repositorio 
builder.Services.AddScoped<ISamlService, SamlServices>();
builder.Services.AddScoped<IDbHelper, DbHelper>();
builder.Services.AddScoped<ILoginAccesoRepository, LoginAccesoRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IJwtGeneratorService, JwtGeneratorService>();

// Registrar MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ObtenerInfoSamlHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginHandler).Assembly));

//jwt opciones
builder.Services.Configure<EntJwt>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<IJwtGeneratorService, JwtGeneratorService>();

builder.Services.AddHttpClient<IMenuService, MenuHttpClient>(client =>
{
    // 2. Lee la URL base de tu archivo de configuración.
    var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["MicroserviceUrls:MenuService"]
                               ?? throw new InvalidOperationException("Falta la URL de MenuService en la configuración."));
});

/*******************************************************/


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

