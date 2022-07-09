using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.PageObject;

namespace Selenium.TheInternet.CSharp.Tests;

[TestFixture]
public class DataTableTests : SetupTeardown
{
    
    [Test]
    public void Confirm_Last_Name_Is_Returned()
    {
        var lastname = "Bach";
        var due = "$51.00";
        var expectedWebSite = "http://www.frank.com";
        
        var context = new BaseContext(driver);
        context.SelectDataTableLink()
            .AssertLinkText(lastname, due, expectedWebSite);

    }
    
    
    
    
}