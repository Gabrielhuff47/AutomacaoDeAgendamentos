using AutomacaoAgendamentos.Domain.Entities;

namespace AutomacaoAgendamentos.Domain.Interfaces;

public interface IServicoRepository
{
    Task<ServicoEntity> CriarServico(ServicoEntity servico);
    Task<TimeSpan> ObterDuracao(int idServico);
}