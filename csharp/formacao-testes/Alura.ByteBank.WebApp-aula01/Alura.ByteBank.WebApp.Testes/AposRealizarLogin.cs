using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Utilitarios;
using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes;
public class AposRealizarLogin(Gerenciador gerenciador) : IClassFixture<Gerenciador>
{
    private readonly IWebDriver driver = gerenciador.driver;
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
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

        //Act
        loginPO.PreencherCampos("", "");
        loginPO.BtnClick();

        // Assert
        Assert.Contains("The Email field is required.", driver.PageSource);
        Assert.Contains("The Senha field is required.", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginComSenhaInvalida()
    {
        // Arrange
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

        //Act
        loginPO.PreencherCampos("andre@email.com", "senha010");
        loginPO.BtnClick();

        // Assert
        Assert.Contains("Login", driver.PageSource);
    }

    [Fact]
    public void RealizarLoginAcessaMenuECadastraCliente()
    {
        // Arrange
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

        //Act
        loginPO.PreencherCampos("andre@email.com", "senha01");
        loginPO.BtnClick();

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
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

        //Act
        loginPO.PreencherCampos("andre@email.com", "senha01");
        loginPO.BtnClick();

        driver.FindElement(By.Id("contacorrente")).Click();

        IReadOnlyCollection<IWebElement> elements 
            = driver.FindElements(By.TagName("a"));

        var elemento = elements.First(x => x.Text.Contains("Detalhes"));

        elemento.Click();

        //Assert
        Assert.Contains("Voltar", driver.PageSource);
    }

    [Fact]
    public void RealizarLoginAcessaListagemDeContasUsandoHomePO()
    {
        // Arrange
        var loginPO = new LoginPO(driver);
        loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

        //Act
        loginPO.PreencherCampos("andre@email.com", "senha01");
        loginPO.BtnClick();

        var homePO = new HomePO(driver);
        homePO.LinkContaCorrenteClick();

        //Assert
        Assert.Contains("Adicionar Conta-Corrente", driver.PageSource);
    }
}