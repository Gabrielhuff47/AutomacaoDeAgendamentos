// using AutomacaoAgendamentos.Service.Interfaces;
// using AutomacaoAgendamentosApi.DTOs.Requests;
// using AutomacaoAgendamentosApi.DTOs.Responses;
// using FastEndpoints;
//
// namespace AutomacaoAgendamentosApi.Controllers.AgendamentoControllers;
//
// public class RemarcarAgendamentoEndpoint(
//     IAgendamentoService agendamentoService)
//     : Endpoint<RemarcarAgendamentoRequest, AgendamentoResponse>
// {
//     public override void Configure()
//     {
//         Put("/agendamento/{idAgendamento}");
//         AllowAnonymous();
//         Tags("Agendamento");
//
//         Description(d => d
//             .Produces<AgendamentoResponse>(200)
//             .ProducesProblem(400)
//             .ProducesProblem(404)
//             .ProducesProblem(409));
//     }
//
//     public override async Task HandleAsync(RemarcarAgendamentoRequest request, CancellationToken ct)
//     {
//         var resultado = await agendamentoService.RemarcarAgendamento(
//             request.IdAgendamento,
//             request.Data,
//             request.HoraInicio,
//             request.UsuarioAtualizacao,
//             ct);
//
//         if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
//             return;
//
//         await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
//     }
// }