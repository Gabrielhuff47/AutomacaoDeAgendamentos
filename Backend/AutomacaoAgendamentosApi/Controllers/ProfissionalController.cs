using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;
using AutomacaoAgendamentosApi.Extensions;
using AutomacaoAgendamentosApi.Mapper;
using DefaultNamespace;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class CriarProfissionalEndpoint : Endpoint<ProfissionalRequest, ProfissionalResponse>
{
    private readonly IProfissionalService _profissionalService;

    public CriarProfissionalEndpoint(IProfissionalService profissionalService)
    {
        _profissionalService = profissionalService;
    }

    public override void Configure()
    {
        Post("/profissional");
        AllowAnonymous();
        Tags("Profissional");
        
        Description(d => d
            .Produces<ProfissionalResponse>(201)
            .ProducesProblem(400)
            .Produces(409));
    }

    public override async Task HandleAsync(ProfissionalRequest profissionalRequest, CancellationToken ct)
    {
        var profissionalEntity = profissionalRequest.ToEntity();
        
        var resultado = await _profissionalService.CriarProfissional(profissionalEntity);
        
        await Send.ResponseAsync(resultado.Dados!.ToResponse(), statusCode: 201, cancellation: ct);
    }
}

public class ExcluirProfissionalEndpoint : Endpoint<DeletarProfissionalRequest>
{
    private readonly IProfissionalService _profissionalService;

    public ExcluirProfissionalEndpoint(IProfissionalService profissionalService)
    {
        _profissionalService = profissionalService;
    }

    public override void Configure()
    {
        Delete("/profissional/{IdProfissional}");
        AllowAnonymous();
        Tags("Profissional");

        Description(d => d
            .Produces(204)
            .Produces(404)
            .Produces(409));
    }

    public override async Task HandleAsync(DeletarProfissionalRequest requisicao, CancellationToken ct)
    {
        var resultado = await _profissionalService.DeletarProfissional(requisicao.IdProfissional);

        if (await resultado.EnviarErroSeFalhouAsync(HttpContext, ct)) return;

        await Send.NoContentAsync(ct);
    }
}