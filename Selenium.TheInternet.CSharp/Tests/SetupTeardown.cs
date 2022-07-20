 using OpenQA.Selenium;

 namespace Selenium.TheInternet.CSharp.Tests;

public class SetupTeardown
{ 
    protected IWebDriver driver;
    protected const string Protocol = "https://";
    protected const string Uri = "the-internet.herokuapp.com/";

    [SetUp]
        protected void Setup()
        {
            driver = WebDriverFactory.SelectBrowser();
            driver.Navigate().GoToUrl(Protocol + Uri);
        }
        
        [TearDown]
        protected void CloseBrowserSession() 
        {
            driver.Quit();
        }
}