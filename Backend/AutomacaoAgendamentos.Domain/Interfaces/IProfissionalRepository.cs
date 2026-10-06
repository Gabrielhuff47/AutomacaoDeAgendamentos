namespace DefaultNamespace;

public interface IProfissionalRepository
{
    Task<ProfissionalEntity> CriarProfissional(ProfissionalEntity profissional);
}