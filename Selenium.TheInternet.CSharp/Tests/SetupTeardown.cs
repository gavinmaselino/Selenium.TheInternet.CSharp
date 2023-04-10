 using NUnit.Framework;
 using OpenQA.Selenium;

 namespace Selenium.TheInternet.CSharp.Tests;

public class SetupTeardown
{ 
    protected IWebDriver Driver;
    protected const string Protocol = "https://";
    protected const string Uri = "the-internet.herokuapp.com/";

    [SetUp]
        public void Setup()
        {
            Driver = WebDriverFactory.InitBrowser();
            Driver.Navigate().GoToUrl($"{Protocol}{Uri}");
        }
        
        [TearDown]
        public void CloseBrowserSession() 
        {
            Driver.Close();
            Driver.Quit();
        }
}