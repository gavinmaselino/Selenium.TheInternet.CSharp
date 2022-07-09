using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.PageObject;

/*
 * https://github.com/SeleniumHQ/selenium/issues/4387 - PageFactory usage
 */

public class BaseContext
{
    public IWebDriver driver;


    public BaseContext(IWebDriver driver)
    {
        this.driver = driver;
        
        //PageFactory.InitElements(driver, this);

    }
    
    //[FindsBy(How = How.XPath, Using = "//a[text() = 'Add/Remove Elements']")]
    // Expression bodied version is consider a better approach.
    private IWebElement linkAddRemove => driver.FindElement(By.XPath("//a[text() = 'Add/Remove Elements']"));
    private IWebElement linkSortableTables => driver.FindElement(By.XPath("//a[text() = 'Sortable Data Tables']"));

    public AddRemoveContext SelectAddRemoveElements()
    {
        linkAddRemove.Click();
        return new AddRemoveContext(driver);
    }

    public DataTableContext SelectDataTableLink()
    {
        linkSortableTables.Click();
        return new DataTableContext(driver);
    }
    
    
    
}