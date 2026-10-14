namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class AlterarSituacaoAgendamentoRequest
{
    public int IdAgendamento { get; set; }
    public int IdSituacao { get; set; }
    public string UsuarioAtualizacao { get; set; }
}