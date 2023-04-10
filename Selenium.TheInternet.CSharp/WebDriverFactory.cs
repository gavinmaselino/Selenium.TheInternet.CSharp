using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace Selenium.TheInternet.CSharp;

public static class WebDriverFactory
{
    private static IWebDriver _driver;
    private static string? _browserName;
    private static bool _headless;
    
    public static IWebDriver InitBrowser()
    {
        _browserName = GetConfigurationValue(config => config.BrowserName.ToLower(), "BrowserName");
        _headless = GetConfigurationValue(config => config.Headless, "Headless");

        switch (_browserName)
        {
            case "chrome":
                if (_headless)
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    _driver = new ChromeDriver(options);
                    break;
                }
                _driver = new ChromeDriver();
                break;
            case "firefox":
                if (_headless)
                {
                    var options = new FirefoxOptions();
                    options.AddArgument("--headless");
                    _driver = new FirefoxDriver(options);
                    break;
                }
                _driver = new FirefoxDriver();
                break;
            case "edge":
                if (_headless)
                {
                    var options = new EdgeOptions();
                    options.AddArgument("--headless");
                    _driver = new EdgeDriver(options);
                    break;
                }
                _driver = new EdgeDriver();
                break;
            case "safari":
                if (_headless)
                {
                    throw new WebDriverException("Safari Browser does not currently support headless mode");
                }
                _driver = new SafariDriver();
                break;
            default:
                if (_headless)
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    _driver = new ChromeDriver(options);
                    break;
                }
                _driver = new ChromeDriver();
                break;
        }
        return _driver;
    }
    
    private static T GetConfigurationValue<T>(Func<WebDriverConfiguration, T> valueSelector, string settingName)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var webDriverConfiguration = new WebDriverConfiguration();
        configuration.GetSection("WebDriverConfiguration").Bind(webDriverConfiguration);

        try
        {
            return valueSelector(webDriverConfiguration);
        }
        catch (NullReferenceException)
        {
            throw new NullReferenceException($"The {settingName} setting has either been mis-spelt or cannot be found in the appsettings file");
        }
    }
}
