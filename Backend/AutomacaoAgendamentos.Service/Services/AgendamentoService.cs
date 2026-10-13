using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class AgendamentoService(IAgendamentoRepository agendamentoRepository) : IAgendamentoService
{
    public async Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agendamentoEntity)
    {
        var agendamentoCriado = await agendamentoRepository.CriarAgendamento(agendamentoEntity);
        return Result<AgendamentoEntity>.Ok(agendamentoCriado);
    }
    
    public async Task<Result<AgendamentoEntity>> ObterAgendamentoPorId(int idAgendamento, CancellationToken ct = default)
    {
        var agendamento = await agendamentoRepository.ObterAgendamentoPorId(idAgendamento, ct);

        return agendamento is null
            ? Result<AgendamentoEntity>.Falha("Agendamento não encontrado.", TipoErro.NaoEncontrado)
            : Result<AgendamentoEntity>.Ok(agendamento);
    }
}