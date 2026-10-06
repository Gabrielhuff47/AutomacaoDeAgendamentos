using AutomacaoAgendamentosApi.DTOs.Responses;
using DefaultNamespace;

namespace AutomacaoAgendamentosApi.Mapper;

public static class ProfissionalMapper
{
   public static ProfissionalEntity ToEntity(this ProfissionalRequest profissionalRequest)
   {
       return new ProfissionalEntity
       {
            Nome = profissionalRequest.Nome,
            Cpf = profissionalRequest.Cpf,
            Usuario =  profissionalRequest.Usuario,
            Senha = profissionalRequest.Senha,
            Email = profissionalRequest.Email,
            Telefone = profissionalRequest.Telefone,
            IdEstabelecimento =  profissionalRequest.IdEstabelecimento,
            IsAdmin =  profissionalRequest.IsAdministrador,
       };
   }

   public static ProfissionalResponse ToResponse(this ProfissionalEntity profissionalEntity)
   {
       return new ProfissionalResponse
       {
           IdProfissional = profissionalEntity.IdProfissional,
           Nome = profissionalEntity.Nome,
           Cpf = profissionalEntity.Cpf,
           Usuario = profissionalEntity.Usuario,
           Email = profissionalEntity.Email,
           Telefone = profissionalEntity.Telefone,
           IdEstabelecimento = profissionalEntity.IdEstabelecimento,
           IsAdministrador = profissionalEntity.IsAdmin,
       };
    }
}