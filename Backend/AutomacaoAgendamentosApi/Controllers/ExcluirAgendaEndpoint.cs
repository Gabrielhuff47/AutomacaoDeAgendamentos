using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.Extensions;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class ExcluirAgendaEndpoint(IAgendaService agendaService)
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("/agenda/{idAgenda}");
        AllowAnonymous();
        Tags("Agenda");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var idAgenda = Route<int>("idAgenda");

        var resultado = await agendaService.ExcluirAgenda(idAgenda, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.NoContentAsync(ct);
    }
}
