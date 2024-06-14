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

    [Fact]
    public void ValidaLinkDeLoginNaHome()
    {
        // Arrange
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://localhost:44309");
        var linkLogin = driver.FindElement(By.LinkText("Login"));

        // Act
        linkLogin.Click();

        // Assert
        Assert.Contains("img", driver.PageSource);
    }

    [Fact]
    public void TentaAcessarAPaginaSemEstarLogado()
    {
        // Arrange
        // Act
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

        // Assert
        Assert.Contains("401", driver.PageSource);
    }

    [Fact]
    public void AcessaPaginaSemEstarLogadoVerificaURL()
    {
        // Arrange
        // Act
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");
        

        // Assert
        Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
        Assert.Contains("401", driver.PageSource);
    }
}