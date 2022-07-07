using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.PageObject;

namespace Selenium.TheInternet.CSharp.Tests;

public class Tests
{
    private WebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        driver = WebDriverFactory.SelectBrowser();
        driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        
    }
    
    [Test]
    public void Assert_Add_Remove_Page_Loads()
    {
        var context = new BaseContext(driver);
        context.SelectAddRemoveElements();
    }
}