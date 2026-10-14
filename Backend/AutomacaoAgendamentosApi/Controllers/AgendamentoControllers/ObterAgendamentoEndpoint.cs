using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;

public class ObterAgendamentoEndpoint(
    IAgendamentoService agendamentoService)
    : Endpoint<ObterAgendamentoRequest, AgendamentoResponse>
{
    public override void Configure()
    {
        Get("/agendamento/{idAgendamento}");
        AllowAnonymous();
        Tags("Agendamento");
    }

    public override async Task HandleAsync(
        ObterAgendamentoRequest request,
        CancellationToken ct)
    {
        var resultado = await agendamentoService
            .ObterAgendamentoPorId(request.IdAgendamento, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
    }
}