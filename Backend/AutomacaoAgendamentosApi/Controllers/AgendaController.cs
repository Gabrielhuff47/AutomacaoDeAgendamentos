using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class CriarAgendaEndpoint(IAgendaService agendaService) : Endpoint<AgendaRequest, AgendaResponse>
{
    public override void Configure()
    {
        Post("/agenda");
        AllowAnonymous();
        Tags("Agenda");
    }

    public override async Task HandleAsync(AgendaRequest agendaRequest, CancellationToken cancellationToken)
    {
        var agendaEntity = agendaRequest.ToEntity();
        
        var resultado = await agendaService.CriarAgenda(agendaRequest.ToEntity());
        
        await Send.ResponseAsync(resultado.Dados!.ToResponse(), statusCode: 201, cancellation: cancellationToken);
    }
}