namespace AutomacaoAgendamentosApi.DTOs.Responses;

public class AgendaResponse
{
    public int IdAgenda { get; set; }
    public int IdProfissional { get; set; }
    public DayOfWeek DiaSemana { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
}