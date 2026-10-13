using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;

namespace AutomacaoAgendamentosApi.Mapper;

public static class AgendamentoMapper
{
    public static AgendamentoEntity ToEntity(this AgendamentoRequest agendamentoRequest)
    {
        return new AgendamentoEntity
        {
            IdProfissional = agendamentoRequest.IdProfissional,
            IdServico = agendamentoRequest.IdServico,
            IdCliente = agendamentoRequest.IdCliente,
            NomeCliente = agendamentoRequest.NomeCliente,
            TelefoneCliente = agendamentoRequest.TelefoneCliente,
            Data = agendamentoRequest.Data,
            HoraInicio = agendamentoRequest.HoraInicio,
            HoraFim = agendamentoRequest.HoraFim,
            IdSituacao = agendamentoRequest.IdSituacao,
            UsuarioAtualizacao = agendamentoRequest.UsuarioAtualizacao
        };
    }

    public static AgendamentoResponse ToResponse(this AgendamentoEntity agendamentoEntity)
    {
        return new AgendamentoResponse()
        {
            IdAgendamento = agendamentoEntity.IdAgendamento,
            IdProfissional = agendamentoEntity.IdProfissional,
            IdServico = agendamentoEntity.IdServico,
            IdCliente = agendamentoEntity.IdCliente,
            NomeCliente = agendamentoEntity.NomeCliente,
            TelefoneCliente = agendamentoEntity.TelefoneCliente,
            Data = agendamentoEntity.Data,
            HoraInicio = agendamentoEntity.HoraInicio,
            HoraFim = agendamentoEntity.HoraFim,
            IdSituacao = agendamentoEntity.IdSituacao,
            UsuarioAtualizacao = agendamentoEntity.UsuarioAtualizacao
        };
    }

}