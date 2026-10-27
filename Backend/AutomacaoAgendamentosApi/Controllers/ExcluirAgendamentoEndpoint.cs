using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.Extensions;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class ExcluirAgendamentoEndpoint(IAgendamentoService agendamentoService)
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("/agendamento/{idAgendamento}");
        AllowAnonymous();
        Tags("Agendamento");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var idAgendamento = Route<int>("idAgendamento");

        var resultado = await agendamentoService.ExcluirAgendamento(idAgendamento, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.NoContentAsync(ct);
    }
}
