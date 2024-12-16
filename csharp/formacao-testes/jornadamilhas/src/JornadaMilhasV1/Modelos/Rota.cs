using JornadaMilhas.Validador;

namespace JornadaMilhas.Modelos;

public class Rota(string origem, string destino) : Valida
{
    public int Id { get; set; }
    public string? Origem { get; set; } = origem;
    public string? Destino { get; set; } = destino;
    protected override void Validar()
    {
        if (Origem is null || Origem.Equals(string.Empty))
        {
            Erros.RegistrarErro("A rota não pode possuir uma origem nula ou vazia.");
        }
        else if (Destino is null || Destino.Equals(string.Empty))
        {
            Erros.RegistrarErro("A rota não pode possuir um destino nulo ou vazio.");
        }
    }
}
