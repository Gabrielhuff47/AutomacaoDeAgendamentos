namespace AutomacaoAgendamentosApi.DTOs.Responses;

public class AgendaResponse
{
    public int IdAgenda { get; set; }
    public int IdProfissional { get; set; }
    public DayOfWeek DiaSemana { get; set; }
    public string HoraInicio { get; set; }
    public string HoraFim { get; set; }
}
