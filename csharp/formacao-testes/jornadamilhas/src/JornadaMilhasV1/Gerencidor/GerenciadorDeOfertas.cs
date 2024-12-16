using JornadaMilhas.Modelos;

namespace JornadaMilhas.Gerencidor;
public class GerenciadorDeOfertas(List<OfertaViagem> ofertaViagem)
{
    public void CadastrarOferta()
    {
        Console.WriteLine("-- Cadastro de ofertas --");
        Console.WriteLine("Informe a cidade de origem: ");
        var origem = Console.ReadLine() ?? throw new Exception("Não pode ficar em branco");

        Console.WriteLine("Informe a cidade de destino: ");
        var destino = Console.ReadLine() ?? throw new Exception("Não pode ficar em branco");

        Console.WriteLine("Informe a data de ida (DD/MM/AAAA): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var dataIda))
        {
            Console.WriteLine("Data de ida inválida.");
            return;
        }

        Console.WriteLine("Informe a data de volta (DD/MM/AAAA): ");
        if (!DateTime.TryParse(Console.ReadLine(), out var dataVolta))
        {
            Console.WriteLine("Data de volta inválida.");
            return;
        }

        Console.WriteLine("Informe o preço: ");
        if (!double.TryParse(Console.ReadLine(), out var preco))
        {
            Console.WriteLine("Formato de preço inválido.");
            return;
        }

        var ofertaCadastrada = new OfertaViagem(new Rota(origem, destino), new Periodo(dataIda, dataVolta), preco);
        AdicionarOfertaNaLista(ofertaCadastrada);

        Console.WriteLine("\nOferta cadastrada com sucesso.");
    }

    public bool AdicionarOfertaNaLista(OfertaViagem? ofertaCadastrada)
    {
        if (ofertaCadastrada == null) return false;
        ofertaViagem.Add(ofertaCadastrada);
        return true;
    }
    public void CarregarOfertas()
    {
        AdicionarOfertaNaLista(new OfertaViagem(new Rota("São Paulo", "Curitiba"), new Periodo(new DateTime(2024, 1, 15), new DateTime(2024, 1, 20)), 500));
        AdicionarOfertaNaLista(new OfertaViagem(new Rota("Recife", "Rio de Janeiro"), new Periodo(new DateTime(2024, 2, 10), new DateTime(2024, 2, 15)), 700));
        AdicionarOfertaNaLista(new OfertaViagem(new Rota("Acre", "Brasília"), new Periodo(new DateTime(2024, 3, 5), new DateTime(2024, 3, 10)), 600));
    }
    public void ExibirTodasAsOfertas()
    {
        Console.WriteLine("\nTodas as ofertas cadastradas: ");
        foreach (var oferta in ofertaViagem)
        {
            Console.WriteLine(oferta);
        }
    }
}