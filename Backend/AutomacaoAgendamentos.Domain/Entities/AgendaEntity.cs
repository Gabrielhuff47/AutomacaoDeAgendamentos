namespace AutomacaoAgendamentos.Domain.Entities;

public class AgendaEntity
{
    public int IdAgenda { get; set; }
    public int IdProfissional { get; set; }
    public DayOfWeek DiaSemana { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public string UsuarioAtualizacao { get; set; } = string.Empty;
    public DateTime DataAtualizacao { get; set; }
}