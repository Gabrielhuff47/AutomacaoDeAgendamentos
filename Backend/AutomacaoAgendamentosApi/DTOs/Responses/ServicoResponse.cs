namespace DefaultNamespace;

public class ServicoResponse
{
    public int IdServico { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TimeOnly Duracao { get; set; }
    public int IdProfissional { get; set; }
    public int IdTipoServico { get; set; }
}