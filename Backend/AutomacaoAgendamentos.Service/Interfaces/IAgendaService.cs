using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Shared;
using DefaultNamespace;

namespace AutomacaoAgendamentos.Service.Interfaces;

public interface IAgendaService
{
    Task<Result<AgendaEntity>> CriarAgenda(AgendaEntity agenda);
}