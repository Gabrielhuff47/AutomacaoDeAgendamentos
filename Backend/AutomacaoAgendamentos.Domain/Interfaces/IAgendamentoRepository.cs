using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IAgendamentoRepository
{
    Task<AgendamentoEntity> CriarAgendamento(AgendamentoEntity agenda);
    Task<AgendamentoEntity?> ObterAgendamentoPorId(int idAgendamento, CancellationToken cancellationToken);
    Task AlterarSituacaoAgendamento(AgendamentoEntity agendamento, CancellationToken cancellationToken);
}