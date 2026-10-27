using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class ProfissionalRepository(AgendaDbContext context) : IProfissionalRepository
{
    public async Task<ProfissionalEntity> CriarProfissional(ProfissionalEntity profissional)
    {
        context.PROFISSIONAL.Add(profissional);
        await context.SaveChangesAsync();
        return profissional;
    }

    public Task<ProfissionalEntity?> ObterPorId(int id)
        => context.PROFISSIONAL.FirstOrDefaultAsync(p => p.IdProfissional == id);

    public async Task<ProfissionalEntity> AtualizarProfissional(ProfissionalEntity profissional, CancellationToken ct = default)
    {
        context.PROFISSIONAL.Update(profissional);
        await context.SaveChangesAsync(ct);
        return profissional;
    }

    public Task<bool> PossuiServicos(int idProfissional)
        => context.SERVICO.AnyAsync(s => s.IdProfissional == idProfissional);

    public async Task DeletarProfissional(ProfissionalEntity profissional)
    {
        context.PROFISSIONAL.Remove(profissional);
        await context.SaveChangesAsync();
    }
}