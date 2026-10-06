using DefaultNamespace;
using Microsoft.EntityFrameworkCore;

namespace AutomacaoAgendamentos.Infrastructure.DataContext;

public class AgendaDbContext(DbContextOptions<AgendaDbContext> options) : DbContext (options)
{   
    public DbSet<ProfissionalEntity> PROFISSIONAL { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgendaDbContext).Assembly);
    }
}