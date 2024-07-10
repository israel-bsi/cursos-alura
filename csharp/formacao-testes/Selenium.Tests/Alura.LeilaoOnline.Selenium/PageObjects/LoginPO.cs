using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects;

public class LoginPO(IWebDriver driver)
{
    private readonly By byFormLogin = By.TagName("form");
    private readonly By byInputLogin = By.Id("Login");
    private readonly By byInputSenha = By.Id("Password");
    private readonly By byBotaoLogin = By.Id("btnLogin");
    private readonly By bySpanErroLogin = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
    private readonly By bySpanErroSenha = By.CssSelector("span.msg-erro[data-valmsg-for=Password]");
    public string EmailMensagemErro => driver.FindElement(bySpanErroLogin).Text;
    public string SenhaMensagemErro => driver.FindElement(bySpanErroSenha).Text;
    public void Visitar() => driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
    public void SubmeteFormulario() => driver.FindElement(byBotaoLogin).Submit();
    public void PreencheFormulario(string login, string senha)
    {
        driver.FindElement(byInputLogin).SendKeys(login);
        driver.FindElement(byInputSenha).SendKeys(senha);
    }
}