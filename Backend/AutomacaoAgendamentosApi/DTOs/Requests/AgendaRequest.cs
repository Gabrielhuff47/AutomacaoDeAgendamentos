namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class AgendaRequest
{
    public int IdProfissional { get; set; }
    public DayOfWeek DiaSemana { get; set; }  
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public string UsuarioAtualizacao { get; set; } = string.Empty;
}