namespace AutomacaoAgendamentosApi.DTOs.Responses;

public class ProfissionalResponse
{
    public int IdProfissional { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Usuario { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public int IdEstabelecimento { get; set; }
    public bool IsAdministrador { get; set; }
}