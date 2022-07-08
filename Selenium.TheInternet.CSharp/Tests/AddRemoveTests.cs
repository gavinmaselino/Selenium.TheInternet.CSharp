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
    public void Delete_Button_Created_And_Count_Is_One()
    {
        var context = new BaseContext(driver);
        
        context.SelectAddRemoveElements()
            .AddNewDeleteElement()
            .AssertDeleteButtonCountIsEqualTo(1);

    }

    [TearDown]
    public void CloseBrowserSession()
    {
        driver.Quit();
    }
}