using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

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

    public async Task<TimeSpan> ObterDuracao(int idServico)
    {
        return await _context.SERVICO
            .AsNoTracking()
            .Where(s => s.IdServico == idServico)
            .Select(s => s.Duracao)
            .FirstOrDefaultAsync();
    }
}