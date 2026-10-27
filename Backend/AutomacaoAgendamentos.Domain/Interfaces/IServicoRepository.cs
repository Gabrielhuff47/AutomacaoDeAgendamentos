using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IServicoRepository
{
    Task<ServicoEntity> CriarServico(ServicoEntity servico);
    Task<TimeSpan> ObterDuracao(int idServico);
    Task<ServicoEntity?> ObterPorId(int idServico, CancellationToken cancellationToken);
    Task<ServicoEntity> AtualizarServico(ServicoEntity servico, CancellationToken cancellationToken);
    Task ExcluirServico(ServicoEntity servico, CancellationToken cancellationToken);
}
