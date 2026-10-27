using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IAgendamentoRepository
{
    Task<AgendamentoEntity> CriarAgendamento(AgendamentoEntity agenda);
    Task<AgendamentoEntity?> ObterAgendamentoPorId(int idAgendamento, CancellationToken cancellationToken);
    Task<List<AgendamentoEntity>> ObterAgendamentosPorProfissional(int idProfissional, CancellationToken cancellationToken);
    Task<List<AgendamentoEntity>> ObterAgendamentosPorProfissionalEData(int idProfissional, DateOnly data, CancellationToken cancellationToken);
    Task<AgendamentoEntity> RemarcarAgendamento(AgendamentoEntity agendamento, CancellationToken cancellationToken);
    Task AlterarSituacaoAgendamento(AgendamentoEntity agendamento, CancellationToken cancellationToken);
    Task ExcluirAgendamento(AgendamentoEntity agendamento, CancellationToken cancellationToken);
    Task<bool> ExisteConflitoHorario(int idProfissional, DateOnly data, TimeSpan horaInicio, TimeSpan horaFim, CancellationToken cancellationToken);
}
