using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class AgendaRepository(AgendaDbContext context) : IAgendaRepository
{
    public async Task<AgendaEntity> CriarAgenda(AgendaEntity agenda)
    {
        context.AGENDA.Add(agenda);
        await context.SaveChangesAsync();
        return agenda;
    }

    /// <summary>
    /// Verifica se o intervalo [horaInicio, horaFim] cabe inteiro dentro de algum
    /// período de expediente cadastrado para o profissional naquele dia da semana.
    /// O profissional pode ter mais de um período no mesmo dia (ex.: 08–12 e 13–18).
    /// </summary>
    public Task<bool> HorarioDentroDoExpediente(int idProfissional, DayOfWeek diaSemana, TimeSpan horaInicio, TimeSpan horaFim, CancellationToken ct = default)
        => context.AGENDA
            .AsNoTracking()
            .AnyAsync(a =>
                a.IdProfissional == idProfissional &&
                a.DiaSemana == diaSemana &&
                a.HoraInicio <= horaInicio &&
                a.HoraFim >= horaFim, ct);
}
