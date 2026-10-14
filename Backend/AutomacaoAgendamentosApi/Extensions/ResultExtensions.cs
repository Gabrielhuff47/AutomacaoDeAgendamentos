

using AutomacaoAgendamentos.Domain.Shared;
using AutomacaoAgendamentos.Domain.Shared.Enums;

namespace AutomacaoAgendamentosApi.Extensions;

public static class ResultExtensions
{
    private static int MapearStatusCode(TipoErro tipoErro) => tipoErro switch
    {
        TipoErro.NaoEncontrado => StatusCodes.Status404NotFound,
        TipoErro.Conflito => StatusCodes.Status409Conflict,
        TipoErro.NaoAutorizado => StatusCodes.Status403Forbidden,
        TipoErro.NaoAutenticado => StatusCodes.Status401Unauthorized,
        _ => StatusCodes.Status400BadRequest
    };

    public static async Task<bool> EnviarErroSeFalhouAsync(this Result resultado, HttpContext httpContext, CancellationToken ct)
    {
        if (resultado.Sucesso)
            return false;

        await EscreverErroAsync(httpContext, resultado.TipoErro, resultado.Mensagem, ct);
        return true;
    }
    private static async Task EscreverErroAsync(HttpContext httpContext, TipoErro tipoErro, string? mensagem, CancellationToken ct)
    {
        httpContext.Response.StatusCode = MapearStatusCode(tipoErro);
        await httpContext.Response.WriteAsJsonAsync(new { mensagem }, ct);
    }
}