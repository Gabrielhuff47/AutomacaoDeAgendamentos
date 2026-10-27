using AutomacaoAgendamentosApi.DTOs.Requests;
using FastEndpoints;
using FluentValidation;

namespace AutomacaoAgendamentosApi.DTOs.Validators;

public class AtualizarAgendaRequestValidator : Validator<AtualizarAgendaRequest>
{
    public AtualizarAgendaRequestValidator()
    {
        RuleFor(x => x.HoraInicio)
            .NotEmpty().WithMessage("Hora de início é obrigatória.")
            .Must(h => TimeSpan.TryParseExact(h, @"hh\:mm", null, out _) ||
                       TimeSpan.TryParseExact(h, @"hh\:mm\:ss", null, out _))
            .WithMessage("Hora de início inválida. Use o formato HH:mm ou HH:mm:ss.");

        RuleFor(x => x.HoraFim)
            .NotEmpty().WithMessage("Hora de fim é obrigatória.")
            .Must(h => TimeSpan.TryParseExact(h, @"hh\:mm", null, out _) ||
                       TimeSpan.TryParseExact(h, @"hh\:mm\:ss", null, out _))
            .WithMessage("Hora de fim inválida. Use o formato HH:mm ou HH:mm:ss.");

        RuleFor(x => x.UsuarioAtualizacao)
            .NotEmpty().WithMessage("Usuário de atualização é obrigatório.");
    }
}
