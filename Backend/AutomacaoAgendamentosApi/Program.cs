using AutomacaoAgendamentos.Infrastructure.DataContext;
using AutomacaoAgendamentos.Infrastructure.Repositories;
using DefaultNamespace;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints()
    .SwaggerDocument(o =>
    {
        o.AutoTagPathSegmentIndex = 2; 
    });

builder.Services.AddOpenApi();

builder.Services.AddControllers();



builder.Services.AddDbContext<AgendaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

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

