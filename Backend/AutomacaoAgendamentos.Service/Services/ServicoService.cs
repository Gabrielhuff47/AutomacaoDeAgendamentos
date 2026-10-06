using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using DefaultNamespace;

namespace AutomacaoAgendamentos.Service.Services;

public class ServicoService : IServicoService
{
    private readonly IServicoRepository _servicoRepository;
    
    public ServicoService(IServicoRepository servicoRepository)
    {
        _servicoRepository = servicoRepository;
    }
    
    public async Task<Result<ServicoEntity>> CriarServico(ServicoEntity servicoEntity)
    {
        var servicoCriado = await _servicoRepository.CriarServico(servicoEntity);
        return Result<ServicoEntity>.Ok(servicoCriado);
    }
}