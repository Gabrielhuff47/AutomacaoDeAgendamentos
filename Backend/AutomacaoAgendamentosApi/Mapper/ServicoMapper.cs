using AutomacaoAgendamentos.Domain.Entities;
using AutomacaoAgendamentosApi.DTOs.Requests;
using AutomacaoAgendamentosApi.DTOs.Responses;

namespace AutomacaoAgendamentosApi.Mapper;

public static class ServicoMapper
{
    public static ServicoEntity ToEntity(this ServicoRequest servicoRequest)
    {
        return new ServicoEntity
        {
            Descricao = servicoRequest.Descricao,
            Valor = servicoRequest.Valor,
            Duracao =  TimeSpan.FromMinutes(servicoRequest.DuracaoMinutos),
            IdProfissional = servicoRequest.IdProfissional,
            IdTipoServico = servicoRequest.IdTipoServico,
            UsuarioAtualizacao =  servicoRequest.UsuarioAtualizacao
        };
    }
    
    public static ServicoResponse ToResponse(this ServicoEntity servicoEntity)
    {
        return new ServicoResponse
        {
            IdServico = servicoEntity.IdServico,
            Descricao = servicoEntity.Descricao,
            Valor = servicoEntity.Valor,
            DuracaoMinutos = (int)servicoEntity.Duracao.TotalMinutes,
            IdProfissional = servicoEntity.IdProfissional,
            IdTipoServico = servicoEntity.IdTipoServico
        };
    }
}
