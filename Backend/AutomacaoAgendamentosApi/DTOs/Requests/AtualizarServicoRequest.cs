namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class AtualizarServicoRequest
{
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public int DuracaoMinutos { get; set; }
    public int IdTipoServico { get; set; }
    public string UsuarioAtualizacao { get; set; } = string.Empty;
}
