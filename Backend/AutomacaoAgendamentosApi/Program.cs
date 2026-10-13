using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using AutomacaoAgendamentos.Infrastructure.Repositories;
using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentos.Service.Services;
using DefaultNamespace;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.Title = "Agenda Automatizada API";
            s.Version = "v1";
        };
    });

builder.Services.AddOpenApi();

builder.Services.AddControllers();



builder.Services.AddDbContext<AgendaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IAgendaService, AgendaService>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

var app = builder.Build();
app.UseFastEndpoints();
app.UseHttpsRedirection();
 
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}
app.Run();

