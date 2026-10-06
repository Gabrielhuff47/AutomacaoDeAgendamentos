using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;

namespace DefaultNamespace;

public interface IServicoService
{
    Task<Result<ServicoEntity>> CriarServico(ServicoEntity servico);
}