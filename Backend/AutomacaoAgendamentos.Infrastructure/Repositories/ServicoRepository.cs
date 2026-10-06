using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;

namespace AutomacaoAgendamentos.Infrastructure.Repositories;

public class ServicoRepository : IServicoRepository
{
    private readonly AgendaDbContext _context;
    
    public ServicoRepository(AgendaDbContext context)
    {
        _context = context;
    }
    
    public async Task<ServicoEntity> CriarServico(ServicoEntity servico)
    {
        _context.SERVICO.Add(servico);
        await _context.SaveChangesAsync();
        return servico;
    }
}