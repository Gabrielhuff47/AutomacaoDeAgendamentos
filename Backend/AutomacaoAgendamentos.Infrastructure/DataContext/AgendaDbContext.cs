using AutomacaoAgendamentos.Domain.Entities;
using DefaultNamespace;
using Microsoft.EntityFrameworkCore;

namespace AutomacaoAgendamentos.Infrastructure.DataContext;

public class AgendaDbContext(DbContextOptions<AgendaDbContext> options) : DbContext (options)
{   
    public DbSet<ProfissionalEntity> PROFISSIONAL { get; set; }
    public DbSet<ServicoEntity> SERVICO { get; set; }
    public DbSet<AgendaEntity> AGENDA { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgendaDbContext).Assembly);
    }
}