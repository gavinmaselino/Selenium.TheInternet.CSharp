using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.PageObject;

public class AddRemoveContext : BaseContext
{
    
    // The base keyword is used to access members of the base class from within a derived class.
    // Only inheriting once as an example to get the base keyword. 
    // In reality, there are no members in Base that can be clicked on from other contexts. 
    public AddRemoveContext(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }
    
    private IWebElement btnAddElement => driver.FindElement(By.XPath("//button[text()='Add Element']"));
    
    private int delBtnCount => driver.FindElements(By.CssSelector("button.added-manually")).Count;

    public AddRemoveContext CreateDeleteButtons(int count)
    {
        for (var i = 0; i < count; i++)
        {
            btnAddElement.Click();
        }

        return this;
    }

    public void AssertDeleteButtonCountIsEqualTo(int expectedcount)
    {
        Assert.That(delBtnCount, Is.EqualTo(expectedcount));
    }
    
    
    
    
}