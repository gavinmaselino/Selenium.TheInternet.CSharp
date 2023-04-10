using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.Context;
/*
 * https://github.com/SeleniumHQ/selenium/issues/4387 - PageFactory usage
 */
public class BaseContext
{
    protected IWebDriver WebDriver;
    public BaseContext(IWebDriver driver)
    {
        WebDriver = driver;
    }

    internal AddRemoveContext SelectAddRemoveElements()
    {
        WebDriver.FindElement(By.CssSelector("a[href='/add_remove_elements/']")).Click();
        return new AddRemoveContext(WebDriver);
    }
    internal DataTableContext SelectDataTableLink()
    {
        WebDriver.FindElement(By.CssSelector("a[href='/tables']")).Click();
        return new DataTableContext(WebDriver);
    }
    internal JsAlertContext SelectJsAlertLink()
    {
        WebDriver.FindElement(By.CssSelector("a[href='/javascript_alerts']")).Click();
        return new JsAlertContext(WebDriver);
    }
    internal DigestAuthenticationContext SelectDigestAuthLink()
    {
        WebDriver.FindElement(By.CssSelector("a[href='/digest_auth']")).Click();
        return new DigestAuthenticationContext(WebDriver);
    }
}