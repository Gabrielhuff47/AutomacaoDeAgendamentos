namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class RemarcarAgendamentoRequest
{
    public int IdServico { get; set; }
    public DateOnly Data { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public string UsuarioAtualizacao { get; set; }
}
