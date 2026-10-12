using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.Mapper;
using DefaultNamespace;
using FastEndpoints;

namespace AutomacaoAgendamentosApi.Controllers;

public class CriarServicoEndpoint : Endpoint<ServicoRequest, ServicoResponse>
{
    private readonly IServicoService _servicoService;

    public CriarServicoEndpoint(IServicoService servicoService)
    {
        _servicoService = servicoService;
    }
    
    public override void Configure()
    {
        Post("/serviço");
        AllowAnonymous();
        Tags("Serviço");
        
        Description(d => d
            .Produces<ServicoResponse>(201)
            .ProducesProblem(400)
            .Produces(409));
    }
    
    public override async Task HandleAsync(ServicoRequest servicoRequest, CancellationToken ct)
    {
        var servicoEntity = servicoRequest.ToEntity();
        
        var resultado = await _servicoService.CriarServico(servicoEntity);
        
        await Send.ResponseAsync(resultado.Dados!.ToResponse(), statusCode: 201, cancellation: ct);
    }
}