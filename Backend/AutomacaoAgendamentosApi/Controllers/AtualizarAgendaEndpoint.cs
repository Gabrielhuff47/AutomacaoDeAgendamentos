using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class AtualizarAgendaEndpoint(IAgendaService agendaService)
    : Endpoint<AtualizarAgendaRequest, AgendaResponse>
{
    public override void Configure()
    {
        Put("/agenda/{idAgenda}");
        AllowAnonymous();
        Tags("Agenda");
    }

    public override async Task HandleAsync(AtualizarAgendaRequest request, CancellationToken ct)
    {
        var idAgenda = Route<int>("idAgenda");

        var horaInicio = TimeSpan.Parse(request.HoraInicio);
        var horaFim = TimeSpan.Parse(request.HoraFim);

        var resultado = await agendaService.AtualizarAgenda(
            idAgenda,
            request.DiaSemana,
            horaInicio,
            horaFim,
            request.UsuarioAtualizacao,
            ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
    }
}
