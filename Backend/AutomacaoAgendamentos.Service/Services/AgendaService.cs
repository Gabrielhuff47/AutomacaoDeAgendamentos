using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class AgendaService(IAgendaRepository agendaRepository) : IAgendaService
{
    public async Task<Result<AgendaEntity>> CriarAgenda(AgendaEntity agendaEntity)
    {
        var agendaCriada = await agendaRepository.CriarAgenda(agendaEntity);
        return Result<AgendaEntity>.Ok(agendaCriada);
    }

    public async Task<Result<AgendaEntity>> AtualizarAgenda(int idAgenda, DayOfWeek diaSemana, TimeSpan horaInicio, TimeSpan horaFim, string usuario, CancellationToken ct = default)
    {
        var agenda = await agendaRepository.ObterPorId(idAgenda, ct);
        if (agenda is null)
            return Result<AgendaEntity>.Falha("Agenda não encontrada.", TipoErro.NaoEncontrado);

        if (horaInicio >= horaFim)
            return Result<AgendaEntity>.Falha("A hora de início deve ser anterior à hora de fim.");

        agenda.DiaSemana = diaSemana;
        agenda.HoraInicio = horaInicio;
        agenda.HoraFim = horaFim;
        agenda.UsuarioAtualizacao = usuario;

        var agendaAtualizada = await agendaRepository.AtualizarAgenda(agenda, ct);
        return Result<AgendaEntity>.Ok(agendaAtualizada);
    }
}
