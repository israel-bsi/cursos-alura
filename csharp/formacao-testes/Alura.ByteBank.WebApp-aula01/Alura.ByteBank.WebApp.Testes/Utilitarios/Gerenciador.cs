using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Alura.ByteBank.WebApp.Testes.Utilitarios;

public class Gerenciador : IDisposable
{
    public IWebDriver driver = new ChromeDriver();
    public void Dispose() => driver.Dispose();
}