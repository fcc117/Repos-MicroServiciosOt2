using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TicketService.Infrastructure.Persistence;
using TicketService.Aplication.Interfaces.Tickets;
using TicketService.Aplication.UseCase.ObtenerTickets;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


// Registrar el repositorio de menu
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// base de datos
builder.Services.AddDbContext<TicketDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdenesTrabajoConnection"), SqlServerOptions =>
    {
        SqlServerOptions.CommandTimeout(120);
    }));

// Registrar MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ObtenerTotalesTicketHandler).Assembly));


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
