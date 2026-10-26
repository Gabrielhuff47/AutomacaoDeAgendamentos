using AutomacaoAgendamentosApi.DTOs.Requests;
using FastEndpoints;
using FluentValidation;

namespace AutomacaoAgendamentosApi.DTOs.Validators;

public class AgendamentoRequestValidator : Validator<AgendamentoRequest>
{
    public AgendamentoRequestValidator()
    {
        RuleFor(x => x.HoraInicio)
            .GreaterThanOrEqualTo(TimeSpan.Zero)
            .LessThan(TimeSpan.FromDays(1))
            .WithMessage("Hora inicial inválida.");
    }
}
