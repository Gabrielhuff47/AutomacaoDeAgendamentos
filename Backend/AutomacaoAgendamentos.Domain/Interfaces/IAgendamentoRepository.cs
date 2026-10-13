using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IAgendamentoRepository
{
    Task<AgendamentoEntity> CriarAgendamento(AgendamentoEntity agenda);
}