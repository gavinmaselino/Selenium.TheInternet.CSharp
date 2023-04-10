using NUnit.Framework;
using Selenium.TheInternet.CSharp.Context;

namespace Selenium.TheInternet.CSharp.Tests;

[TestFixture]
public class DataTableTests : SetupTeardown
{
    [TestCase("Bach", "$51.00", "http://www.frank.com")]
    [TestCase("Conway", "$50.00", "http://www.timconway.com")]
    public void Confirm_Url_Is_Found_In_Table_One(string lastname, string due, string expectedWebSite)
    {
        var context = new BaseContext(Driver);
        context.SelectDataTableLink()
            .AssertTableOneUrl(lastname, due, expectedWebSite);
    }

    [TestCase("Smith", "jsmith@gmail.com","http://www.jsmith.com")]
    [TestCase("Doe", "jdoe@hotmail.com","http://www.jdoe.com")]
    public void Confirm_Url_Is_Found_In_Table_Two(string lastname, string email, string expectedWebSite)
    {
        var context = new BaseContext(Driver);
        context
            .SelectDataTableLink()
            .AssertTableTwoUrl(lastname, email, expectedWebSite);
    }
}