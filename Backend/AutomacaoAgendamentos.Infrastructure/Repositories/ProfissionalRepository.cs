using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using DefaultNamespace;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class ProfissionalRepository : IProfissionalRepository
{
    private readonly AgendaDbContext _context;

    public ProfissionalRepository(AgendaDbContext context)
    {
        _context = context;
    }

    public async Task<ProfissionalEntity> CriarProfissional(ProfissionalEntity profissional)
    {
        _context.PROFISSIONAL.Add(profissional);
        await _context.SaveChangesAsync();
        return profissional;
    }
}