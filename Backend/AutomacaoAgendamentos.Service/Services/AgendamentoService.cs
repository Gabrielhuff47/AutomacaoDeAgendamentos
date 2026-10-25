using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class AgendamentoService(IAgendamentoRepository agendamentoRepository, IServicoRepository servicoRepository) : IAgendamentoService
{
    public async Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agendamentoEntity)
    {
        bool verificaDisponibilidade = await agendamentoRepository.ObterAgendamentoDataHorario(agendamentoEntity.Data,
            agendamentoEntity.HoraInicio, agendamentoEntity.IdServico);
        
        if (verificaDisponibilidade)
        {
            var agendamentoCriado = await agendamentoRepository.CriarAgendamento(agendamentoEntity);
            return Result<AgendamentoEntity>.Ok(agendamentoCriado);    
        }

        return Result<AgendamentoEntity>.Falha("Falha no agedamento, horário indisponivel", TipoErro.Conflito);

    }
    
    public async Task<Result<AgendamentoEntity>> ObterAgendamentoPorId(int idAgendamento, CancellationToken ct = default)
    {
        var agendamento = await agendamentoRepository.ObterAgendamentoPorId(idAgendamento, ct);

        return agendamento is null
            ? Result<AgendamentoEntity>.Falha("Agendamento não encontrado.", TipoErro.NaoEncontrado)
            : Result<AgendamentoEntity>.Ok(agendamento);
    }

    public async Task<Result<AgendamentoEntity>> AlterarSituacaoAgendamento(int idAgendamento, int idSituacao, string usuario, CancellationToken ct = default)
    {
        var agendamento = await agendamentoRepository.ObterAgendamentoPorId(idAgendamento, ct);

        if(agendamento is null)
            return Result<AgendamentoEntity>.Falha("AgendamentoNaoEncontrado.", TipoErro.NaoEncontrado);

        if (agendamento.IdSituacao == (int)TipoSituacao.FINALIZADO || agendamento.IdSituacao == (int)TipoSituacao.CANCELADO)
            return Result<AgendamentoEntity>.Falha("Agendamento já está cancelado ou concluído.");
        
        agendamento.IdSituacao = idSituacao;
        agendamento.UsuarioAtualizacao = usuario;
        
        await agendamentoRepository.AlterarSituacaoAgendamento(agendamento, ct);
        return Result<AgendamentoEntity>.Ok(agendamento);
     
    }

    public async Task<TimeSpan> CalculaHoraFim(TimeSpan horaInicio, int idServico)
    {
        var tempoServico = await servicoRepository.ObterDuracao(idServico);
        var horaFim = horaInicio + tempoServico;
        return horaFim;
    }
}