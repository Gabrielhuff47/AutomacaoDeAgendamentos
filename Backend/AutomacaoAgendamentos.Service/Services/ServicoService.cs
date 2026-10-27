using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class ServicoService(IServicoRepository servicoRepository) : IServicoService
{
    public async Task<Result<ServicoEntity>> CriarServico(ServicoEntity servicoEntity)
    {
        var servicoCriado = await servicoRepository.CriarServico(servicoEntity);
        return Result<ServicoEntity>.Ok(servicoCriado);
    }

    public async Task<Result<ServicoEntity>> AtualizarServico(int idServico, string descricao, decimal valor, int duracaoMinutos, int idTipoServico, string usuario, CancellationToken ct = default)
    {
        var servico = await servicoRepository.ObterPorId(idServico, ct);
        if (servico is null)
            return Result<ServicoEntity>.Falha("Serviço não encontrado.", TipoErro.NaoEncontrado);

        servico.Descricao = descricao;
        servico.Valor = valor;
        servico.Duracao = TimeSpan.FromMinutes(duracaoMinutos);
        servico.IdTipoServico = idTipoServico;
        servico.UsuarioAtualizacao = usuario;

        var servicoAtualizado = await servicoRepository.AtualizarServico(servico, ct);
        return Result<ServicoEntity>.Ok(servicoAtualizado);
    }

    public async Task<Result<bool>> ExcluirServico(int idServico, CancellationToken ct = default)
    {
        var servico = await servicoRepository.ObterPorId(idServico, ct);
        if (servico is null)
            return Result<bool>.Falha("Serviço não encontrado.", TipoErro.NaoEncontrado);

        await servicoRepository.ExcluirServico(servico, ct);
        return Result<bool>.Ok(true);
    }
}