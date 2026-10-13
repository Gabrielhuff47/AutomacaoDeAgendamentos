using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IAgendamentoService
{
    Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agenda);
    Task<Result<AgendamentoEntity>> ObterAgendamentoPorId(int idAgendamento, CancellationToken ct = default);
}