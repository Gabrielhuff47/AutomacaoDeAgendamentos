using DefaultNamespace;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IProfissionalRepository
{
    Task<ProfissionalEntity> CriarProfissional(ProfissionalEntity profissional);
    Task<ProfissionalEntity?> ObterPorId(int idProfissional);   
    Task<bool> PossuiServicos(int idProfissional);
    Task DeletarProfissional(ProfissionalEntity profissional);
}