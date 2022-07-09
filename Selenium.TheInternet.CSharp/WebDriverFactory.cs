using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium.TheInternet.CSharp;

public static class WebDriverFactory
{
    private static IWebDriver Driver;
    private static WebDriverWait wait;
    private const string ChosenBrowser = "Chrome";
    private const bool Headless = true;

    public static IWebDriver SelectBrowser()
    {
        if (ChosenBrowser.ToLower() == "chrome")
        {
            var options = new ChromeOptions();
            if (Headless)
            {
                options.AddArgument("--headless");
            }

            Driver = new ChromeDriver(options);
        }
        
        wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        return Driver;
    }
    
}
