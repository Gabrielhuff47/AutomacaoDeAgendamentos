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

    public Task<AgendaEntity?> ObterPorId(int idAgenda, CancellationToken ct = default)
        => context.AGENDA
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.IdAgenda == idAgenda, ct);

    public async Task<AgendaEntity> AtualizarAgenda(AgendaEntity agenda, CancellationToken ct = default)
    {
        context.AGENDA.Update(agenda);
        await context.SaveChangesAsync(ct);
        return agenda;
    }

    public async Task ExcluirAgenda(AgendaEntity agenda, CancellationToken ct = default)
    {
        context.AGENDA.Remove(agenda);
        await context.SaveChangesAsync(ct);
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
