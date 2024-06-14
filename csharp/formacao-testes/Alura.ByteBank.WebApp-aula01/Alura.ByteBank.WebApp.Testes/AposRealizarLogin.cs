using Alura.ByteBank.WebApp.Testes.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes;
public class AposRealizarLogin(ITestOutputHelper output)
{
    private readonly ChromeDriver driver = new();
    [Fact]
    public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
    {
        // Arrange
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

        //Act
        loginPO.PreencherCampos("andre@email.com", "senha01");
        loginPO.BtnClick();

        // Assert
        Assert.Contains("Agência", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginSemPreencherCampos()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

        var btnLogar = driver.FindElement(By.Id("btn-logar"));

        // Act
        btnLogar.Click();

        // Assert
        Assert.Contains("The Email field is required.", driver.PageSource);
        Assert.Contains("The Senha field is required.", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginComSenhaInvalida()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

        var login = driver.FindElement(By.Id("Email"));
        var senha = driver.FindElement(By.Id("Senha"));
        var btnLogar = driver.FindElement(By.Id("btn-logar"));

        login.SendKeys("andre@email.com");
        senha.SendKeys("senha010");

        // Act
        btnLogar.Click();

        // Assert
        Assert.Contains("Login", driver.PageSource);
    }

    [Fact]
    public void RealizarLoginAcessaMenuECadastraCliente()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

        var login = driver.FindElement(By.Name("Email"));
        var senha = driver.FindElement(By.Name("Senha"));

        login.SendKeys("andre@email.com");
        senha.SendKeys("senha01");

        driver.FindElement(By.Id("btn-logar")).Click();

        driver.FindElement(By.LinkText("Cliente")).Click();

        driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

        driver.FindElement(By.Name("Identificador")).Click();
        driver.FindElement(By.Name("Identificador")).SendKeys("13518b88-aef7-487b-83a9-e059b98c374d");
        driver.FindElement(By.Name("CPF")).Click();
        driver.FindElement(By.Name("CPF")).SendKeys("69981034096");
        driver.FindElement(By.Name("Nome")).Click();
        driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");
        driver.FindElement(By.Name("Profissao")).Click();
        driver.FindElement(By.Name("Profissao")).SendKeys("Cientista");

        // Act
        driver.FindElement(By.CssSelector(".btn-primary")).Click();
        driver.FindElement(By.LinkText("Home")).Click();

        // Assert
        Assert.Contains("Logout", driver.PageSource);
        driver.Quit();
    }

    [Fact]
    public void RealizarLoginAcessaListagemDeContas()
    {
        // Arrange
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

        var login = driver.FindElement(By.Name("Email"));
        var senha = driver.FindElement(By.Name("Senha"));

        login.SendKeys("andre@email.com");
        senha.SendKeys("senha01");

        driver.FindElement(By.Id("btn-logar")).Click();

        driver.FindElement(By.Id("contacorrente")).Click();

        IReadOnlyCollection<IWebElement> elements 
            = driver.FindElements(By.TagName("a"));

        var elemento = elements.First(x => x.Text.Contains("Detalhes"));

        elemento.Click();

        //Assert
        Assert.Contains("Voltar", driver.PageSource);
    }
}