using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IAgendamentoService
{
    Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agenda, CancellationToken ct = default);
    Task<Result<AgendamentoEntity>> ObterAgendamentoPorId(int idAgendamento, CancellationToken ct = default);
    Task<Result<AgendamentoEntity>> AlterarSituacaoAgendamento(int idAgendamento, int idSituacao, string usuario, CancellationToken ct = default);
}
