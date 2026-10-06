using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;

namespace DefaultNamespace;

public class ProfissionalService : IProfissionalService
{
    private readonly IProfissionalRepository _profissionalRepository;
    
    public ProfissionalService(IProfissionalRepository profissionalRepository)
    {
        _profissionalRepository = profissionalRepository;
    }
    
    public async Task<Result<ProfissionalEntity>> CriarProfissional(ProfissionalEntity profissional)
    {
        
        profissional.DataAtualizacao = DateTime.UtcNow;
        profissional.UsuarioAtualizacao = "Sistema";

        var profissionalCriado = await _profissionalRepository.CriarProfissional(profissional);
        return Result<ProfissionalEntity>.Ok(profissionalCriado);
    }
}