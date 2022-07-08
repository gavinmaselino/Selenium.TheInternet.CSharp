using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Selenium.TheInternet.CSharp.PageObject;

/*
 * https://github.com/SeleniumHQ/selenium/issues/4387 - PageFactory usage
 */

public class BaseContext
{
    public WebDriver driver;
    private WebDriverWait wait;

    public BaseContext(WebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //PageFactory.InitElements(driver, this);

    }
    
    //[FindsBy(How = How.XPath, Using = "//a[text() = 'Add/Remove Elements']")]
    // Expression bodied version is consider a better approach.
    private IWebElement linkAddRemove => driver.FindElement(By.XPath("//a[text() = 'Add/Remove Elements']"));

    public AddRemoveContext SelectAddRemoveElements()
    {
        linkAddRemove.Click();
        return new AddRemoveContext(driver);
    }
    
    
    
}