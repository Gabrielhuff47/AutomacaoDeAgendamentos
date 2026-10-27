using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class AtualizarServicoEndpoint(IServicoService servicoService)
    : Endpoint<AtualizarServicoRequest, ServicoResponse>
{
    public override void Configure()
    {
        Put("/servico/{idServico}");
        AllowAnonymous();
        Tags("Servico");
    }

    public override async Task HandleAsync(AtualizarServicoRequest request, CancellationToken ct)
    {
        var idServico = Route<int>("idServico");

        var resultado = await servicoService.AtualizarServico(
            idServico,
            request.Descricao,
            request.Valor,
            request.DuracaoMinutos,
            request.IdTipoServico,
            request.UsuarioAtualizacao,
            ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
    }
}
