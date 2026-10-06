using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using DefaultNamespace;
using Microsoft.EntityFrameworkCore;

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
    public Task<ProfissionalEntity?> ObterPorId(int id)
        => _context.PROFISSIONAL.FirstOrDefaultAsync(p => p.IdProfissional == id);
    public Task<bool> PossuiServicos(int idProfissional)
        => _context.SERVICO.AnyAsync(s => s.IdProfissional == idProfissional);

    public async Task DeletarProfissional(ProfissionalEntity profissional)
    {
        _context.PROFISSIONAL.Remove(profissional);
        await _context.SaveChangesAsync();
    }
}