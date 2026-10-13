using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class AgendamentoService(IAgendamentoRepository agendamentoRepository) : IAgendamentoService
{
    public async Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agendamentoEntity)
    {
        var agendaCriada = await agendamentoRepository.CriarAgendamento(agendamentoEntity);
        return Result<AgendamentoEntity>.Ok(agendaCriada);
    }
}