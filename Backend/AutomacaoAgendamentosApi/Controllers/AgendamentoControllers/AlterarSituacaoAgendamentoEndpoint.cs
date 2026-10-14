using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;

public class AlterarSituacaoAgendamentoEndpoint(IAgendamentoService agendamentoService) : Endpoint<AlterarSituacaoAgendamentoRequest, AgendamentoResponse>
{
    public override void Configure()
    {
        Patch("/agendamento/{idAgendamento}/situacao");
        AllowAnonymous();
        Tags("Agendamento");
        Description(d => d
            .Produces<AgendamentoResponse>(200)
            .ProducesProblem(400)
            .ProducesProblem(404));
    }
    
    public override async Task HandleAsync(AlterarSituacaoAgendamentoRequest request, CancellationToken ct)
    {
        var resultado = await agendamentoService.AlterarSituacaoAgendamento(
            request.IdAgendamento, request.IdSituacao, request.UsuarioAtualizacao, ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;
        
        await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
    }
}
