using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class AgendamentoRepository(AgendaDbContext context) : IAgendamentoRepository
{
    public async Task<AgendamentoEntity> CriarAgendamento(AgendamentoEntity agendamento)
    {
        context.AGENDAMENTO.Add(agendamento);
        await context.SaveChangesAsync();
        return agendamento;
    }
    
    public Task<AgendamentoEntity?> ObterAgendamentoPorId(int idAgendamento, CancellationToken ct = default) =>
        context.AGENDAMENTO
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdAgendamento == idAgendamento, ct);

    public async Task AlterarSituacaoAgendamento(AgendamentoEntity agendamento, CancellationToken ct = default)
    {
        context.AGENDAMENTO.Update(agendamento);
        await context.SaveChangesAsync(ct);
    }
}