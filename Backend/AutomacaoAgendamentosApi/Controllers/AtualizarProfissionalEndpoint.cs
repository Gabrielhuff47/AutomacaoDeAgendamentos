using AutomacaoAgendamentos.Service.Interfaces;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class AtualizarProfissionalEndpoint(IProfissionalService profissionalService)
    : Endpoint<AtualizarProfissionalRequest, ProfissionalResponse>
{
    public override void Configure()
    {
        Patch("/profissional/{idProfissional}");
        AllowAnonymous();
        Tags("Profissional");
    }

    public override async Task HandleAsync(AtualizarProfissionalRequest request, CancellationToken ct)
    {
        var idProfissional = Route<int>("idProfissional");

        var resultado = await profissionalService.AtualizarProfissional(
            idProfissional,
            request.Nome,
            request.Email,
            request.Telefone,
            request.Senha,
            request.UsuarioAtualizacao,
            ct);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct))
            return;

        await Send.OkAsync(resultado.Dados!.ToResponse(), ct);
    }
}
