using OpenQA.Selenium;

namespace Alura.ByteBank.WebApp.Testes.PageObjects;
public class LoginPO(IWebDriver driver)
{
    private readonly By campoEmail = By.Id("Email");
    private readonly By campoSenha = By.Id("Senha");
    private readonly By btnLogar = By.Id("btn-logar");
    public void Navegar(string url) => driver.Navigate().GoToUrl(url);
    public void PreencherCampos(string email, string senha)
    {
        driver.FindElement(campoSenha).SendKeys(senha);
        driver.FindElement(campoEmail).SendKeys(email);
    }
    public void BtnClick() => driver.FindElement(btnLogar).Click();
}