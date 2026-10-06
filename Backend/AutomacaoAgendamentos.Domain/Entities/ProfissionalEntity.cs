namespace DefaultNamespace;

public class ProfissionalEntity
{
    public int IdProfissional { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public int IdEstabelecimento { get; set; }
    public bool IsAdmin { get; set; }
    
    
    public DateTime DataAtualizacao { get; set; }
    public string UsuarioAtualizacao { get; set; } = string.Empty;
}