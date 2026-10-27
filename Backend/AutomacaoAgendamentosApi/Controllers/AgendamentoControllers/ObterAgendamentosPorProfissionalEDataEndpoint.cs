using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;

public class ObterAgendamentosPorProfissionalEDataEndpoint(IAgendamentoService agendamentoService)
    : EndpointWithoutRequest<List<AgendamentoResponse>>
{
    public override void Configure()
    {
        Get("/agendamento/profissional/{idProfissional}/data/{data}");
        AllowAnonymous();
        Tags("Agendamento");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var idProfissional = Route<int>("idProfissional");
        var data = Route<DateOnly>("data");

        var resultado = await agendamentoService.ObterAgendamentosPorProfissionalEData(idProfissional, data, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.Select(a => a.ToResponse()).ToList(), ct);
    }
}
