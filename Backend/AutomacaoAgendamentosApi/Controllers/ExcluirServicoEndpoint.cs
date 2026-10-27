using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.Extensions;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class ExcluirServicoEndpoint(IServicoService servicoService)
    : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("/servico/{idServico}");
        AllowAnonymous();
        Tags("Servico");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var idServico = Route<int>("idServico");

        var resultado = await servicoService.ExcluirServico(idServico, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.NoContentAsync(ct);
    }
}
