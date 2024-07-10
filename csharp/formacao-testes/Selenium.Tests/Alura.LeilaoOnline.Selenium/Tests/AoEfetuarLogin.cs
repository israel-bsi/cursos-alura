using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.Tests;

[Collection("Chrome Driver")]
public class AoEfetuarLogin(TestFixture fixture)
{
    private readonly IWebDriver driver = fixture.Driver;

    [Fact]
    public void DadosCredenciaisValidasDeveIrParaDashboard()
    {
        // Arrange
        var loginPO = new LoginPO(driver);
        loginPO.Visitar();
        loginPO.PreencheFormulario("fulano@example.org", "123");

        // Act
        loginPO.SubmeteFormulario();

        // Assert
        Assert.Contains("Dashboard", driver.Title);
    }

    [Fact]
    public void DadosCredenciaisValidasDeveContinuarLogin()
    {
        // Arrange
        var loginPO = new LoginPO(driver);
        loginPO.Visitar();
        loginPO.PreencheFormulario("fulano@example.org", "");

        // Act
        loginPO.SubmeteFormulario();

        // Assert
        Assert.Contains("Login", driver.PageSource);
    }
}