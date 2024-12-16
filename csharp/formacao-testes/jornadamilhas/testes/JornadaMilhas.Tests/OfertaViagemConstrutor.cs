using JornadaMilhas.Modelos;

namespace JornadaMilhas.Tests;

public class OfertaViagemConstrutor
{
    [Theory]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
    [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
    [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1, false)]
    [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
    [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-01", -500, false)]
    public void RetornaOfertaValidaQuandoDadosValidos
        (string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
    {
        // Arrange
        var rota = new Rota(origem, destino);
        var dataIdaDt = DateTime.Parse(dataIda);
        var dataVoltaDt = DateTime.Parse(dataVolta);
        var periodo = new Periodo(dataIdaDt, dataVoltaDt);

        // Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        // Assert
        Assert.Equal(validacao, oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDeRotaNulaOuPeriodoInvalidosQuandoRotaNula()
    {
        // Arrange
        Rota? rota = null;
        var periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        var preco = 100.0;

        // Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        // Assert
        Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }

    [Fact]
    public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
    {
        // Arrange
        var rota = new Rota("OrigemTeste", "DestinoTeste");
        var periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        var preco = -250;

        // Act
        var oferta = new OfertaViagem(rota, periodo, preco);

        // Assert
        Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        Assert.False(oferta.EhValido);
    }
}