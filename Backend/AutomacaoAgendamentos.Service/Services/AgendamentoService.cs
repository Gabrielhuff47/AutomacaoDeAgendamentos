using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class AgendamentoService(
    IAgendamentoRepository agendamentoRepository,
    IServicoRepository servicoRepository,
    IAgendaRepository agendaRepository) : IAgendamentoService
{
    public async Task<Result<AgendamentoEntity>> CriarAgendamento(AgendamentoEntity agendamentoEntity, CancellationToken ct = default)
    {
        var servico = await servicoRepository.ObterPorId(agendamentoEntity.IdServico, ct);

        if (servico is null)
            return Result<AgendamentoEntity>.Falha("Serviço não encontrado.", TipoErro.NaoEncontrado);

        if (servico.IdProfissional != agendamentoEntity.IdProfissional)
            return Result<AgendamentoEntity>.Falha("O serviço informado não pertence a este profissional.");

        var inicioAgendamento = agendamentoEntity.Data.ToDateTime(TimeOnly.FromTimeSpan(agendamentoEntity.HoraInicio));
        if (inicioAgendamento < DateTime.Now)
            return Result<AgendamentoEntity>.Falha("Não é possível agendar em uma data/horário que já passou.", TipoErro.RegraDeNegocio);
        
        var horaFim = CalculaHoraFim(agendamentoEntity.HoraInicio, servico.Duracao);

        if (horaFim.Days > 0)
            return Result<AgendamentoEntity>.Falha("O serviço ultrapassa o fim do dia.");

        // 4. O horário precisa caber dentro do expediente do profissional naquele dia da semana
        var dentroDoExpediente = await agendaRepository.HorarioDentroDoExpediente(
            agendamentoEntity.IdProfissional,
            agendamentoEntity.Data.DayOfWeek,
            agendamentoEntity.HoraInicio,
            horaFim,
            ct);

        if (!dentroDoExpediente)
            return Result<AgendamentoEntity>.Falha("Horário fora do expediente do profissional.", TipoErro.Conflito);

        // 5. Não pode sobrepor outro agendamento ativo do mesmo profissional
        var existeConflito = await agendamentoRepository.ExisteConflitoHorario(
            agendamentoEntity.IdProfissional,
            agendamentoEntity.Data,
            agendamentoEntity.HoraInicio,
            horaFim,
            ct);

        if (existeConflito)
            return Result<AgendamentoEntity>.Falha("Falha no agendamento, horário indisponível.", TipoErro.Conflito);

        agendamentoEntity.HoraFim = horaFim;
        agendamentoEntity.IdSituacao = (int)TipoSituacao.AGENDADO;

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

    public async Task<Result<List<AgendamentoEntity>>> ObterAgendamentosPorProfissional(int idProfissional, CancellationToken ct = default)
    {
        var agendamentos = await agendamentoRepository.ObterAgendamentosPorProfissional(idProfissional, ct);
        return Result<List<AgendamentoEntity>>.Ok(agendamentos);
    }

    public async Task<Result<List<AgendamentoEntity>>> ObterAgendamentosPorProfissionalEData(int idProfissional, DateOnly data, CancellationToken ct = default)
    {
        var agendamentos = await agendamentoRepository.ObterAgendamentosPorProfissionalEData(idProfissional, data, ct);
        return Result<List<AgendamentoEntity>>.Ok(agendamentos);
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

    /// <summary>
    /// Calcula a hora final do atendimento com base na hora inicial + duração do serviço.
    /// </summary>
    private static TimeSpan CalculaHoraFim(TimeSpan horaInicio, TimeSpan duracaoServico)
        => horaInicio + duracaoServico;
}
