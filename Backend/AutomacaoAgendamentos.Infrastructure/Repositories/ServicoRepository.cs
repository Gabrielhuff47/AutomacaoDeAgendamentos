using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class ServicoRepository(AgendaDbContext context) : IServicoRepository
{
    public async Task<ServicoEntity> CriarServico(ServicoEntity servico)
    {
        context.SERVICO.Add(servico);
        await context.SaveChangesAsync();
        return servico;
    }

    public async Task<TimeSpan> ObterDuracao(int idServico)
    {
        return await context.SERVICO
            .AsNoTracking()
            .Where(s => s.IdServico == idServico)
            .Select(s => s.Duracao)
            .FirstOrDefaultAsync();
    }

    public Task<ServicoEntity?> ObterPorId(int idServico, CancellationToken ct = default)
        => context.SERVICO
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.IdServico == idServico, ct);

    public async Task<ServicoEntity> AtualizarServico(ServicoEntity servico, CancellationToken ct = default)
    {
        context.SERVICO.Update(servico);
        await context.SaveChangesAsync(ct);
        return servico;
    }

    public async Task ExcluirServico(ServicoEntity servico, CancellationToken ct = default)
    {
        context.SERVICO.Remove(servico);
        await context.SaveChangesAsync(ct);
    }
}
