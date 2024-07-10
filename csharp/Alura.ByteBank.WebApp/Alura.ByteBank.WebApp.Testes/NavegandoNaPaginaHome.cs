using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes;

public class NavegandoNaPaginaHome
{
    private readonly ChromeDriver driver = new();

    [Fact]
    public void CarregaPaginaHomeEVerificaTituloDaPagina()
    {
        driver.Navigate().GoToUrl("https://localhost:44309");
        
        Assert.Contains("WebApp", driver.Title);
    }

    [Fact]
    public void CarregadaPaginaHomeVerificaExistenciaLinkLoginEHome()
    {
        driver.Navigate().GoToUrl("https://localhost:44309");
        
        Assert.Contains("Login", driver.PageSource);
        Assert.Contains("Home", driver.PageSource);
    }

    [Fact]
    public void ValidaLinkDeLoginNaHome()
    {
        driver.Navigate().GoToUrl("https://localhost:44309");
        var linkLogin = driver.FindElement(By.LinkText("Login"));
        
        linkLogin.Click();
        
        Assert.Contains("img", driver.PageSource);
    }

    [Fact]
    public void AcessaPaginaSemEstarLogado()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");           
        
        Assert.Contains("401", driver.PageSource);
    }
}