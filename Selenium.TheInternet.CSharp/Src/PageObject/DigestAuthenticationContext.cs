using OpenQA.Selenium;


namespace Selenium.TheInternet.CSharp.PageObject;

public class DigestAuthenticationContext
{
    private IWebDriver driver;
    public DigestAuthenticationContext(IWebDriver driver)
    {
        this.driver = driver;
    }
    
    private IWebElement SuccessMessage => driver.FindElement(By.XPath("//p[contains(text(),'Congratulations! You must have the proper credentials.')]"));
    

    public DigestAuthenticationContext EnterCredentials(string user, string pw, string protocol, string address)
    {
        var url  = protocol + user +":"+ pw +"@"+ address;
        driver.Navigate().GoToUrl(url);
        
        return this;
    }

    public void AssertSuccessMessageIsDisplayed()
    {
        Assert.That(SuccessMessage.Displayed,Is.True);
    }
    
}