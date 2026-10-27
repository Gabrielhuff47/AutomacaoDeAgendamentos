namespace AutomacaoAgendamentosApi.DTOs.Requests;

public class AtualizarProfissionalRequest
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? Senha { get; set; }
    public string UsuarioAtualizacao { get; set; } = string.Empty;
}
