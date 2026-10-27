using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared.Enums;
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

    public Task<List<AgendamentoEntity>> ObterAgendamentosPorProfissional(int idProfissional, CancellationToken ct = default) =>
        context.AGENDAMENTO
            .AsNoTracking()
            .Where(a => a.IdProfissional == idProfissional)
            .OrderBy(a => a.Data)
            .ThenBy(a => a.HoraInicio)
            .ToListAsync(ct);

    public Task<List<AgendamentoEntity>> ObterAgendamentosPorProfissionalEData(int idProfissional, DateOnly data, CancellationToken ct = default) =>
        context.AGENDAMENTO
            .AsNoTracking()
            .Where(a => a.IdProfissional == idProfissional && a.Data == data)
            .OrderBy(a => a.HoraInicio)
            .ToListAsync(ct);

    public async Task<AgendamentoEntity> RemarcarAgendamento(AgendamentoEntity agendamento, CancellationToken ct = default)
    {
        context.AGENDAMENTO.Update(agendamento);
        await context.SaveChangesAsync(ct);
        return agendamento;
    }

    public async Task AlterarSituacaoAgendamento(AgendamentoEntity agendamento, CancellationToken ct = default)
    {
        context.AGENDAMENTO.Update(agendamento);
        await context.SaveChangesAsync(ct);
    }

    public async Task ExcluirAgendamento(AgendamentoEntity agendamento, CancellationToken ct = default)
    {
        context.AGENDAMENTO.Remove(agendamento);
        await context.SaveChangesAsync(ct);
    }

    /// <summary>
    /// Verifica se já existe algum agendamento ativo do profissional, na mesma data,
    /// que se sobreponha ao intervalo [horaInicio, horaFim).
    /// Agendamentos CANCELADOS ou REMARCADOS liberam o horário e não são considerados.
    /// Um serviço pode começar exatamente quando o anterior termina (ex.: termina 10:00, próximo começa 10:00).
    /// </summary>
    public Task<bool> ExisteConflitoHorario(int idProfissional, DateOnly data, TimeSpan horaInicio, TimeSpan horaFim, CancellationToken ct = default)
    {
        const int cancelado = (int)TipoSituacao.CANCELADO;
        const int remarcado = (int)TipoSituacao.REMARCADO;

        return context.AGENDAMENTO
            .AsNoTracking()
            .AnyAsync(a =>
                a.IdProfissional == idProfissional &&
                a.Data == data &&
                a.IdSituacao != cancelado &&
                a.IdSituacao != remarcado &&
                a.HoraInicio < horaFim &&
                a.HoraFim > horaInicio, ct);
    }
}
