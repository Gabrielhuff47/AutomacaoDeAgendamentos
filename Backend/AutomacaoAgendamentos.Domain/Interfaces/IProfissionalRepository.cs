using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IProfissionalRepository
{
    Task<ProfissionalEntity> CriarProfissional(ProfissionalEntity profissional);
    Task<ProfissionalEntity?> ObterPorId(int idProfissional);
    Task<ProfissionalEntity> AtualizarProfissional(ProfissionalEntity profissional, CancellationToken cancellationToken);
    Task<bool> PossuiServicos(int idProfissional);
    Task DeletarProfissional(ProfissionalEntity profissional);
}