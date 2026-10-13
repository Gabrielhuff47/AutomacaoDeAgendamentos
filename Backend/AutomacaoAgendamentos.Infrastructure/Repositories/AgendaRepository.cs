using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class AgendaRepository(AgendaDbContext context) : IAgendaRepository
{
    public async Task<AgendaEntity> CriarAgenda(AgendaEntity agenda)
    {
        context.AGENDA.Add(agenda);
        await context.SaveChangesAsync();
        return agenda;
    }
}