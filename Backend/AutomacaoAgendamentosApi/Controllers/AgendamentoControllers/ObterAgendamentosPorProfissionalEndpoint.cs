using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;

public class ObterAgendamentosPorProfissionalEndpoint(IAgendamentoService agendamentoService)
    : EndpointWithoutRequest<List<AgendamentoResponse>>
{
    public override void Configure()
    {
        Get("/agendamento/profissional/{idProfissional}");
        AllowAnonymous();
        Tags("Agendamento");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var idProfissional = Route<int>("idProfissional");

        var resultado = await agendamentoService.ObterAgendamentosPorProfissional(idProfissional, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.Select(a => a.ToResponse()).ToList(), ct);
    }
}
