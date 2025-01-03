using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.Tests;

[Collection("Chrome Driver")]
public class AoNavegarParaHome(TestFixture fixture)
{
    private readonly IWebDriver driver = fixture.Driver;

    [Fact]
    public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
    {
        // Arrange
        // Act
        driver.Navigate().GoToUrl("http://localhost:5000");

        // Assert
        Assert.Contains("Leil�es", driver.Title);
    }

    [Fact]
    public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
    {
        // Arrange
        // Act
        driver.Navigate().GoToUrl("http://localhost:5000");

        // Assert
        Assert.Contains("Pr�ximos Leil�es", driver.PageSource);
    }

    [Fact]
    public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
    {
        // Arrange 
        // Act
        driver.Navigate().GoToUrl("http://localhost:5000");

        // Assert
        var form = driver.FindElement(By.TagName("form"));
        var spans = form.FindElements(By.TagName("span"));
        foreach (var span in spans)
        {
            Assert.True(string.IsNullOrEmpty(span.Text));
        }
    }
}