using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IAgendamentoService
{
    Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agenda);
}