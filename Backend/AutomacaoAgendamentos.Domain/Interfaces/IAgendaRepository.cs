using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IAgendaRepository
{
    Task<AgendaEntity> CriarAgenda(AgendaEntity agenda);
    Task<bool> HorarioDentroDoExpediente(int idProfissional, DayOfWeek diaSemana, TimeSpan horaInicio, TimeSpan horaFim, CancellationToken cancellationToken);
}
