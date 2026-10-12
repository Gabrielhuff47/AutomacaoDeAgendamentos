using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using DefaultNamespace;

namespace AutomacaoAgendamentos.Service.Services;

public class ProfissionalService : IProfissionalService
{
    private readonly IProfissionalRepository _profissionalRepository;
    
    public ProfissionalService(IProfissionalRepository profissionalRepository)
    {
        _profissionalRepository = profissionalRepository;
    }
    
    public async Task<Result<ProfissionalEntity>> CriarProfissional(ProfissionalEntity profissional)
    {
        
        profissional.UsuarioAtualizacao = "Sistema";

        var profissionalCriado = await _profissionalRepository.CriarProfissional(profissional);
        return Result<ProfissionalEntity>.Ok(profissionalCriado);
    }
    
    public async Task<Result> DeletarProfissional(int idProfissional)
    {
        var profissional = await _profissionalRepository.ObterPorId(idProfissional);

        if (profissional is null)
            return Result.Falha("Profissional não encontrado.", TipoErro.NaoEncontrado);

        if (await _profissionalRepository.PossuiServicos(idProfissional))
            return Result.Falha(
                "Não é possível excluir o profissional, pois ele possui serviços cadastrados.",
                TipoErro.Conflito);

        await _profissionalRepository.DeletarProfissional(profissional);
        return Result.Ok();
    }
}