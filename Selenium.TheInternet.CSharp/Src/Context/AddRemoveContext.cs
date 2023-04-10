using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.Context;

internal class AddRemoveContext : BaseContext
{
    // The base keyword is used to access members of the base class from within a derived class.
    // Only inheriting once as an example to get the base keyword. 
    // In reality, there are no members in BaseContext that can be accessed from other contexts. 
    internal AddRemoveContext(IWebDriver driver) : base(driver)
    {
        WebDriver = driver;
    }
    internal AddRemoveContext CreateDeleteButtons(int count)
    {
        var btnAddElement = WebDriver.FindElement(By.XPath("//button[text()='Add Element']"));
        for (var i = 0; i < count; i++)
        {
            btnAddElement.Click();
        }
        return this;
    }
    internal void AssertDeleteButtonCountIsEqualTo(int expectedcount)
    {
        var delBtnCount = WebDriver.FindElements(By.CssSelector("button.added-manually")).Count;
        Assert.That(delBtnCount, Is.EqualTo(expectedcount));
    }
}