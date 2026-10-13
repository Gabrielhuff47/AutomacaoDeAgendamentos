using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class AgendamentoRepository(AgendaDbContext context) : IAgendamentoRepository
{
    public async Task<AgendamentoEntity> CriarAgendamento(AgendamentoEntity agendamento)
    {
        context.AGENDAMENTO.Add(agendamento);
        await context.SaveChangesAsync();
        return agendamento;
    }
}