using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.Context;

internal class DataTableContext
{
    private readonly IWebDriver _driver;

    public DataTableContext(IWebDriver driver)
    {
        _driver = driver;
    }
    
    internal void AssertTableOneUrl(string lastname, string due, string expectedwebsite)
    {
        var iterationResult = IterateTableOne(lastname, due);
        Assert.That(iterationResult, Is.EqualTo(expectedwebsite));
    }
    
    internal void AssertTableTwoUrl(string lastname, string email, string expectedwebsite)
    {
        var iterationResult = IterateTableTwo(lastname, email);
        Assert.That(iterationResult, Is.EqualTo(expectedwebsite));
    }

    private string? IterateTableOne(string lastname, string due)
    {
        var table = _driver.FindElement(By.Id("table1"));

        var trCollection = table.FindElements(By.CssSelector("tbody > tr"));

        foreach (var element in trCollection) 
        {
            var tdCollection = element.FindElements(By.CssSelector("td"));

            var lastNameColTxt = tdCollection[0].Text;
            var dueColTxt = tdCollection[3].Text;
            if (lastNameColTxt != lastname || dueColTxt != due) continue;
            
            var websiteTxt = tdCollection[4].Text;
            return websiteTxt;
        }
        return null;
    }

    private string? IterateTableTwo(string lastname, string emailaddress)
    {
        var table = _driver.FindElement(By.CssSelector("table#table2"));

        var rows = table.FindElements(By.CssSelector("tr"))
            .Skip(1) // Skip the header row
            .ToList();

        foreach (var row in rows)
        {
            var lastNameTxt = row.FindElement(By.CssSelector(".last-name")).Text;
            var emailTxt = row.FindElement(By.CssSelector(".email")).Text;

            if (lastNameTxt != lastname || emailTxt != emailaddress) continue;

            var websiteTxt = row.FindElement(By.CssSelector(".web-site")).Text;
            return websiteTxt;
        }
        return null;
    }
}