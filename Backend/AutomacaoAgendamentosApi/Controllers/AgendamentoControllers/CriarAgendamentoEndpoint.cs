using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;

public class CriarAgendamentoEndpoint(IAgendamentoService agendamentoService) : Endpoint<AgendamentoRequest, AgendamentoResponse>
{
    public override void Configure()
    {
        Post("/agendamento");
        AllowAnonymous();
        Tags("Agendamento");        
    }

    public override async Task HandleAsync(AgendamentoRequest agendamentoRequest, CancellationToken cancellationToken)
    {
        var agendamentoEntity = agendamentoRequest.ToEntity();

        var resultado = await agendamentoService.CriarAgendamento(agendamentoEntity, cancellationToken);
        
        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, cancellationToken))
            return;
        
        await Send.ResponseAsync(resultado.Dados!.ToResponse(), statusCode: 201, cancellation: cancellationToken);
    }
}