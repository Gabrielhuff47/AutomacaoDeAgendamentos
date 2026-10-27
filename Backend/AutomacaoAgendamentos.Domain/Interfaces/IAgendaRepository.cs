using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IAgendaRepository
{
    Task<AgendaEntity> CriarAgenda(AgendaEntity agenda);
    Task<AgendaEntity?> ObterPorId(int idAgenda, CancellationToken cancellationToken);
    Task<AgendaEntity> AtualizarAgenda(AgendaEntity agenda, CancellationToken cancellationToken);
    Task ExcluirAgenda(AgendaEntity agenda, CancellationToken cancellationToken);
    Task<bool> HorarioDentroDoExpediente(int idProfissional, DayOfWeek diaSemana, TimeSpan horaInicio, TimeSpan horaFim, CancellationToken cancellationToken);
}
