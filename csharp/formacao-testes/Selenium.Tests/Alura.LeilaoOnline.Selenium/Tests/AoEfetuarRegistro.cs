using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.Tests;

[Collection("Chrome Driver")]
public class AoEfetuarRegistro(TestFixture fixture)
{
    private readonly IWebDriver driver = fixture.Driver;

    [Fact]
    public void DadosInformacoesValidasDeveIrParaPaginaDeAgradecimento()
    {
        // Arrange
        driver.Navigate().GoToUrl("http://localhost:5000");

        var inputNome = driver.FindElement(By.Id("Nome"));
        var inputEmail = driver.FindElement(By.Id("Email"));
        var inputSenha = driver.FindElement(By.Id("Password"));
        var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
        var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

        inputNome.SendKeys("Israel");
        inputEmail.SendKeys("israel@email.com");
        inputSenha.SendKeys("123");
        inputConfirmSenha.SendKeys("123");

        // Act
        botaoRegistro.Click();

        // Assert
        Assert.Contains("Obrigado", driver.PageSource);
    }

    [Theory]
    [InlineData("", "", "", "")]
    [InlineData("Israel", "", "", "")]
    [InlineData("Israel", "israel", "", "")]
    [InlineData("Israel", "israel@email.com", "123", "321")]
    [InlineData("Israel", "israel@email.com", "123", "")]
    public void DadosInformacoesValidasDeveContinuarNaPaginaHome
        (string nome, string email, string senha, string confirmSenha)
    {
        // Arrange
        driver.Navigate().GoToUrl("http://localhost:5000");

        var inputNome = driver.FindElement(By.Id("Nome"));
        var inputEmail = driver.FindElement(By.Id("Email"));
        var inputSenha = driver.FindElement(By.Id("Password"));
        var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));
        var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

        inputNome.SendKeys(nome);
        inputEmail.SendKeys(email);
        inputSenha.SendKeys(senha);
        inputConfirmSenha.SendKeys(confirmSenha);

        // Act
        botaoRegistro.Click();

        // Assert
        Assert.Contains("section-registro", driver.PageSource);
    }

    [Fact]
    public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
    {
        // Arrange
        driver.Navigate().GoToUrl("http://localhost:5000");
        var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

        // Act
        botaoRegistro.Click();

        // Assert
        var element = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
        Assert.Equal("The Nome field is required.", element.Text);
    }

    [Fact]
    public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
    {
        // Arrange
        var registroPO = new RegistroPO(driver);
        registroPO.Visitar();

        registroPO.PreencheFormulario("", "daniel", "", "");
        
        // Act
        registroPO.SubmeteFormulario();

        // Assert
        Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
    }
}