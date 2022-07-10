using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.PageObject;

namespace Selenium.TheInternet.CSharp.Tests;

[TestFixture]
public class DataTableTests : SetupTeardown
{
    
    [Test]
    public void Confirm_Url_Is_Found_In_Table_One()
    {
        const string lastname = "Bach";
        const string due = "$51.00";
        const string expectedWebSite = "http://www.frank.com";
        
        var context = new BaseContext(driver);
        context.SelectDataTableLink()
            .AssertTableOneUrl(lastname, due, expectedWebSite);

    }

    [Test]
    public void Confirm_Url_Is_Found_In_Table_Two()
    {
        const string lastname = "Doe";
        const string email = "jdoe@hotmail.com";
        const string expectedWebSite = "http://www.jdoe.com";

        var context = new BaseContext(driver);
            context
            .SelectDataTableLink()
            .AssertTableTwoUrl(lastname, email, expectedWebSite);

    }
    
    
    
    
    
    
}