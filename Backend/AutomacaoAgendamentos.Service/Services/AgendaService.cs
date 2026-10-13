using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class AgendaService : IAgendaService
{
    private readonly IAgendaRepository _agendaRepository;
    
    public AgendaService(IAgendaRepository agendaRepository)
    {
        _agendaRepository = agendaRepository;
    }
    
    public async Task<Result<AgendaEntity>> CriarAgenda(AgendaEntity agendaEntity)
    {
        var agendaCriada = await _agendaRepository.CriarAgenda(agendaEntity);
        return Result<AgendaEntity>.Ok(agendaCriada);
    }
}