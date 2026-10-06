namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class ServicoRequest
{
    public string Descricao { get; set; }
    public decimal Valor { get; set; } 
    public TimeOnly Duracao { get; set; }
    public int IdProfissional { get; set; }
    public int IdTipoServico { get; set; }
    public string UsuarioAtualizacao { get; set; }
}