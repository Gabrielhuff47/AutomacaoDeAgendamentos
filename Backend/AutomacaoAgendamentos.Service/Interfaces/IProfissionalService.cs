using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IProfissionalService
{
    Task<Result<ProfissionalEntity>> CriarProfissional(ProfissionalEntity profissional);
    Task<Result<ProfissionalEntity>> AtualizarProfissional(int idProfissional, string? nome, string? email, string? telefone, string? senha, string usuario, CancellationToken ct = default);
    Task<Result> DeletarProfissional(int idProfissional);
}  