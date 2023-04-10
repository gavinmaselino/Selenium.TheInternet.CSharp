using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.Extensions;

namespace Selenium.TheInternet.CSharp.Context;

public class DigestAuthenticationContext
{
    private readonly IWebDriver _driver;
    public DigestAuthenticationContext(IWebDriver driver)
    {
        _driver = driver;
    }
    public DigestAuthenticationContext EnterCredentials(string user, string pw, string protocol, string address)
    {
        var url  = $"{protocol}{user}:{pw}@{address}";
        _driver.Navigate().GoToUrl(url);
        return this;
    }

    public void AssertSuccessMessageIsDisplayed()
    {
        var successMessage = _driver.FindElement(By.XPath("//p[contains(text(),'Congratulations! You must have the proper credentials.')]"));
        
        //var selector = "div.example p";
        //var text = "Congratulations! You must have the proper credentials. ";
        //var successMessage = WebElementExtensions.FindElementWithAssociatedText(selector, text);
        Assert.That(successMessage.Displayed,Is.True);
    }
    
}