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
        Post("/criar-profissional");
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