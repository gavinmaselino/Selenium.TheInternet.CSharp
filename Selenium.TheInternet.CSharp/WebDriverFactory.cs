using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.TheInternet.CSharp;

public static class WebDriverFactory
{
    private static WebDriver driver;
    private static string _chosenBrowser = "Chrome";

    public static WebDriver SelectBrowser()
    {
        if (_chosenBrowser.ToLower() == "chrome")
        {
            driver = new ChromeDriver();
        }

        return driver;
    }
    
}
