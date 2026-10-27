using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;

public class RemarcarAgendamentoEndpoint(IAgendamentoService agendamentoService)
    : Endpoint<RemarcarAgendamentoRequest, AgendamentoResponse>
{
    public override void Configure()
    {
        Put("/agendamento/{idAgendamento}/remarcar");
        AllowAnonymous();
        Tags("Agendamento");
    }

    public override async Task HandleAsync(RemarcarAgendamentoRequest request, CancellationToken ct)
    {
        var idAgendamento = Route<int>("idAgendamento");

        var resultado = await agendamentoService.RemarcarAgendamento(
            idAgendamento,
            request.IdServico,
            request.Data,
            request.HoraInicio,
            request.UsuarioAtualizacao,
            ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
    }
}
