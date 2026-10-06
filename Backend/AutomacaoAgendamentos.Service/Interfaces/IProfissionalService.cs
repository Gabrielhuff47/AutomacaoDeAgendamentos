using AutomacaoAgendamentos.Domain.Shared;

namespace DefaultNamespace;

public interface IProfissionalService
{
    Task<Result<ProfissionalEntity>> CriarProfissional(ProfissionalEntity profissional);
    Task<Result> DeletarProfissional(int idProfissional);
}  