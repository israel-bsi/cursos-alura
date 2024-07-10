using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes;

public class AposRealizarLogin
{
    private readonly ChromeDriver driver = new();

    [Fact]
    public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
        var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
        var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML
          
        login.SendKeys("israel@email.com");
        senha.SendKeys("senha01");

        btnLogar.Click();

        Assert.Contains("Agência", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginSemPreencherCampos()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

        btnLogar.Click();

        Assert.Contains("The Email field is required.", driver.PageSource);
        Assert.Contains("The Senha field is required.", driver.PageSource);
    }

    [Fact]
    public void TentaRealizarLoginComSenhaInvalida()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
        var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
        var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

        login.SendKeys("israel@email.com");
        senha.SendKeys("senha010");//senha inválida.

        btnLogar.Click();

        Assert.Contains("Login", driver.PageSource);
    }

    [Fact]
    public void AposRealizarLoginAcessaMenuAgencia()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");
        var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
        var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML
        var btnLogar = driver.FindElement(By.Id("btn-logar"));//Selecionar elementos do HTML

        login.SendKeys("israel@email.com");
        senha.SendKeys("senha01");
        btnLogar.Click();

        var linkMenu = driver.FindElement(By.Id("agencia"));

        linkMenu.Click();

        Assert.Contains("Adicionar Agência", driver.PageSource);
    }

    [Fact]
    public void RealizarLoginECadastrarCliente()
    {
        driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

        var login = driver.FindElement(By.Id("Email"));//Selecionar elementos do HTML
        var senha = driver.FindElement(By.Id("Senha"));//Selecionar elementos do HTML

        Thread.Sleep(1000);

        login.SendKeys("israel@email.com");
        senha.SendKeys("senha01");

        Thread.Sleep(1000);

        driver.FindElement(By.Id("btn-logar")).Click();

        Thread.Sleep(1000);

        driver.FindElement(By.LinkText("Cliente")).Click();

        Thread.Sleep(1000);

        driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

        Thread.Sleep(1000);

        driver.FindElement(By.Name("Identificador")).Click();
        driver.FindElement(By.Name("Identificador")).SendKeys("8137fbc3-5c79-465a-8410-72b80fa508bc");

        Thread.Sleep(1000);

        driver.FindElement(By.Name("CPF")).Click();
        driver.FindElement(By.Name("CPF")).SendKeys("55166294033");

        Thread.Sleep(1000);

        driver.FindElement(By.Name("Nome")).Click();
        driver.FindElement(By.Name("Nome")).SendKeys("Israel Silva");

        Thread.Sleep(1000);

        driver.FindElement(By.Name("Profissao")).Click();
        driver.FindElement(By.Name("Profissao")).SendKeys("Developer");

        Thread.Sleep(1000);

        driver.FindElement(By.CssSelector(".btn-primary")).Click();

        Thread.Sleep(1000);
        
        Assert.Contains("Israel Silva", driver.PageSource);

        driver.Quit();
    }
}