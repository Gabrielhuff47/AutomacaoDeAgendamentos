namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class AtualizarAgendaRequest
{
    public DayOfWeek DiaSemana { get; set; }
    public string HoraInicio { get; set; } = string.Empty;
    public string HoraFim { get; set; } = string.Empty;
    public string UsuarioAtualizacao { get; set; } = string.Empty;
}
