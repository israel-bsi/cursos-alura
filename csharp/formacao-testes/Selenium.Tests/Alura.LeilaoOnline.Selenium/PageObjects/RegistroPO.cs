using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects;

public class RegistroPO(IWebDriver driver)
{
    private readonly By byFormRegistro = By.TagName("form");
    private readonly By byInputNome = By.Id("Nome");
    private readonly By byInputEmail = By.Id("Email");
    private readonly By byInputSenha = By.Id("Password");
    private readonly By byInputConfirmSenha = By.Id("ConfirmPassword");
    private readonly By byBotaoRegistro = By.Id("btnRegistro");
    private readonly By bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
    public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;
    public void Visitar() => driver.Navigate().GoToUrl("http://localhost:5000");
    public void SubmeteFormulario() => driver.FindElement(byBotaoRegistro).Click();
    public void PreencheFormulario(string nome, string email, string senha, string confirmSenha)
    {
        driver.FindElement(byInputNome).SendKeys(nome);
        driver.FindElement(byInputEmail).SendKeys(email);
        driver.FindElement(byInputSenha).SendKeys(senha);
        driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
    }
}