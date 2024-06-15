using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;

public class HomePO(IWebDriver driver)
{
    private readonly By linkHome = By.Id("home");
    private readonly By linkContaCorrente = By.Id("contacorrente");
    private readonly By linkClientes = By.Id("clientes");
    private readonly By linkAgencias = By.Id("agencia");
    public void Navegar(string url) => driver.Navigate().GoToUrl(url);
    public void LinkHomeClick() => driver.FindElement(linkHome).Click();
    public void LinkContaCorrenteClick() => driver.FindElement(linkContaCorrente).Click();
    public void LinkClientesClick() => driver.FindElement(linkClientes).Click();
    public void LinkAgenciasClick() => driver.FindElement(linkAgencias).Click();
}