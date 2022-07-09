 using OpenQA.Selenium;

 namespace Selenium.TheInternet.CSharp.Tests;

public class SetupTeardown
{ 
    protected IWebDriver driver;
        
        [SetUp]
        protected void Setup()
        {
            driver = WebDriverFactory.SelectBrowser();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
        }
        
        [TearDown]
        protected void CloseBrowserSession() 
        {
            driver.Quit();
        }
}