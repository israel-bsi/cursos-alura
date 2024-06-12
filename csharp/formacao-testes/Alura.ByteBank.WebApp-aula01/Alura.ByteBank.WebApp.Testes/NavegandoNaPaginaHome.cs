using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Alura.ByteBank.WebApp.Testes;

public class NavegandoNaPaginaHome
{
    [Fact]
    public void CarregaPaginaHomeEVerificaTituloDaPagina()
    {
        // Arrange
        IWebDriver driver = new ChromeDriver();

        // Act
        driver.Navigate().GoToUrl("https://localhost:44309");

        // Assert
        Assert.Contains("WebApp", driver.Title);

    }

    [Fact]
    public void CarregaPaginaHomeEVerificaExistenciaLinkLoginEHome()
    {
        // Arrange
        IWebDriver driver = new ChromeDriver();

        // Act
        driver.Navigate().GoToUrl("https://localhost:44309");

        // Assert
        Assert.Contains("Login", driver.PageSource);
        Assert.Contains("Home", driver.PageSource);
    }   
}