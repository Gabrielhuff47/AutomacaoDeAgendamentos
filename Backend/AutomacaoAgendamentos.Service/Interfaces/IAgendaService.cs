using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IAgendaService
{
    Task<Result<AgendaEntity>> CriarAgenda(AgendaEntity agenda);
    Task<Result<AgendaEntity>> AtualizarAgenda(int idAgenda, DayOfWeek diaSemana, TimeSpan horaInicio, TimeSpan horaFim, string usuario, CancellationToken ct = default);
}
