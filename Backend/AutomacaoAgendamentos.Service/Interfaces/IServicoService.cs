using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IServicoService
{
    Task<Result<ServicoEntity>> CriarServico(ServicoEntity servico);
    Task<Result<ServicoEntity>> AtualizarServico(int idServico, string descricao, decimal valor, int duracaoMinutos, int idTipoServico, string usuario, CancellationToken ct = default);
    Task<Result<bool>> ExcluirServico(int idServico, CancellationToken ct = default);
}