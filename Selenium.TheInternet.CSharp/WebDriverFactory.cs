using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace Selenium.TheInternet.CSharp;

public static class WebDriverFactory
{
    private static IWebDriver driver;
    public static IWebDriver InitBrowser(BrowserName browserName = BrowserName.Chrome, bool headless = true)
    {
        switch (browserName)
        {
            case BrowserName.Chrome:
                if (headless)
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    driver = new ChromeDriver(options);
                    break;
                }
                driver = new ChromeDriver();
                break;
            case BrowserName.FireFox:
                if (headless)
                {
                    var options = new FirefoxOptions();
                    options.AddArgument("--headless");
                    driver = new FirefoxDriver(options);
                    break;
                }
                driver = new FirefoxDriver();
                break;
            case BrowserName.Edge:
                if (headless)
                {
                    var options = new EdgeOptions();
                    options.AddArgument("--headless");
                    driver = new EdgeDriver(options);
                    break;
                }
                driver = new EdgeDriver();
                break;
            case BrowserName.Safari:
                if (headless)
                {
                    throw new WebDriverException("Safari Browser does not currently support headless mode");
                }
                driver = new SafariDriver();
                break;
        }
        return driver;
    }
    
    public enum BrowserName
    {
        Chrome,
        FireFox,
        Edge,
        Safari
    }
}
