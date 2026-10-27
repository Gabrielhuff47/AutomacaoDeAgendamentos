using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentos.Domain.Interfaces;
using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;
using AutomacaoAgendamentos.Service.Interfaces;

namespace AutomacaoAgendamentos.Service.Services;

public class ProfissionalService(IProfissionalRepository profissionalRepository) : IProfissionalService
{
    public async Task<Result<ProfissionalEntity>> CriarProfissional(ProfissionalEntity profissional)
    {
        profissional.UsuarioAtualizacao = "Sistema";

        var profissionalCriado = await profissionalRepository.CriarProfissional(profissional);
        return Result<ProfissionalEntity>.Ok(profissionalCriado);
    }

    public async Task<Result<ProfissionalEntity>> AtualizarProfissional(int idProfissional, string? nome, string? email, string? telefone, string? senha, string usuario, CancellationToken ct = default)
    {
        var profissional = await profissionalRepository.ObterPorId(idProfissional);
        if (profissional is null)
            return Result<ProfissionalEntity>.Falha("Profissional não encontrado.", TipoErro.NaoEncontrado);

        if (nome is not null) profissional.Nome = nome;
        if (email is not null) profissional.Email = email;
        if (telefone is not null) profissional.Telefone = telefone;
        if (senha is not null) profissional.Senha = senha;
        profissional.UsuarioAtualizacao = usuario;

        var profissionalAtualizado = await profissionalRepository.AtualizarProfissional(profissional, ct);
        return Result<ProfissionalEntity>.Ok(profissionalAtualizado);
    }

    public async Task<Result> DeletarProfissional(int idProfissional)
    {
        var profissional = await profissionalRepository.ObterPorId(idProfissional);

        if (profissional is null)
            return Result.Falha("Profissional não encontrado.", TipoErro.NaoEncontrado);

        if (await profissionalRepository.PossuiServicos(idProfissional))
            return Result.Falha(
                "Não é possível excluir o profissional, pois ele possui serviços cadastrados.",
                TipoErro.Conflito);

        await profissionalRepository.DeletarProfissional(profissional);
        return Result.Ok();
    }
}