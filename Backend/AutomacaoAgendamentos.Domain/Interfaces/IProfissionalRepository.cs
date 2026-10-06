using DefaultNamespace;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IProfissionalRepository
{
    Task<ProfissionalEntity> CriarProfissional(ProfissionalEntity profissional);
}