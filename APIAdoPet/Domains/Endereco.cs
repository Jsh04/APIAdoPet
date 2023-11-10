using Microsoft.EntityFrameworkCore;

namespace APIAdoPet.Domains;

[Owned]
public class Endereco
{
    public string Logradouro { get; set; } = String.Empty;
    public string Bairro { get; set; } = String.Empty;
    public string Cep { get; set; } = String.Empty;
    public string Cidade { get; set; } = String.Empty;
    public string Estado { get; set; } = String.Empty;

}
