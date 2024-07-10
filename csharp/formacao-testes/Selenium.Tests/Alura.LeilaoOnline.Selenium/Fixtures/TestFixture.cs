using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Alura.LeilaoOnline.Selenium.Fixtures;

public class TestFixture : IDisposable
{
    public IWebDriver Driver { get; } = new ChromeDriver();
    public void Dispose() => Driver.Quit();
}