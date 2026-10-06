namespace AutomacaoAgendamentos.Domain.Entities;

public class ServicoEntity
{
    public int IdServico { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; } 
    public TimeOnly Duracao { get; set; }
    public int IdProfissional { get; set; }
    public int IdTipoServico { get; set; }
    
    public DateTime DataAtualizacao { get; set; }
    public string UsuarioAtualizacao { get; set; } = string.Empty;
}