namespace AutomacaoAgendamentos.Domain.Entities;

public class AgendamentoEntity
{
    public int IdAgendamento { get; set; }
    public int IdProfissional { get; set; }
    public int IdServico { get; set; }
    public int IdCliente { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string TelefoneCliente { get; set; } = string.Empty;
    public DateOnly Data { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public int IdSituacao { get; set; }
    
    public string UsuarioAtualizacao { get; set; } = string.Empty;
    public DateTime DataAtualizacao { get; set; }
}