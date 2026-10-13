using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;

namespace AutomacaoAgendamentosApi.Mapper;

public static class AgendaMapper
{
    public static AgendaEntity ToEntity(this AgendaRequest agendaRequest)
    {
        return new AgendaEntity
        {
            IdProfissional = agendaRequest.IdProfissional,
            DiaSemana = agendaRequest.DiaSemana,
            HoraInicio = agendaRequest.HoraInicio,
            HoraFim = agendaRequest.HoraFim,
            UsuarioAtualizacao = agendaRequest.UsuarioAtualizacao
        };
    }
    
    public static AgendaResponse ToResponse(this AgendaEntity entity)
    {
        return new AgendaResponse
        {
        IdAgenda = entity.IdAgenda,
        IdProfissional = entity.IdProfissional,
        DiaSemana = entity.DiaSemana,
        HoraInicio = entity.HoraInicio,
        HoraFim = entity.HoraFim
        };
    }    
}