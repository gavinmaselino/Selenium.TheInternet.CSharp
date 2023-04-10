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
        string? websiteTxt = null;
        
        IList<IWebElement> trCollection = table.FindElements(By.CssSelector("tbody > tr"));

        foreach (var element in trCollection) 
        {
            IList<IWebElement> tdCollection = element.FindElements(By.CssSelector("td"));

            var lastNameColTxt = tdCollection[0].Text;
            var dueColTxt = tdCollection[3].Text;
            if (lastNameColTxt != lastname || dueColTxt != due) continue;
            
            foreach (var ele in tdCollection)
            {
                if (ele.Text != "edit delete") continue;
                var colIndex = tdCollection.IndexOf(ele);
                websiteTxt = tdCollection[colIndex-1].Text;
            }
        }
        return websiteTxt;
    }

    private string? IterateTableTwo(string lastname, string emailaddress)
    {
        var table = _driver.FindElement(By.CssSelector("table#table2"));
        var trCollection = table.FindElements(By.CssSelector("tbody > tr"));
        
        string? websiteTxt = null;
        
        foreach (var element in trCollection)
        {
            var tdCollection = element.FindElements(By.CssSelector("td"));
            var lastNameIndex = 0;
            var lastNameIndexFound = false;
            var emailIndex = 0;
            var emailIndexFound = false;
            var websiteIndex = 0;
            var websiteIndexFound = false;
            
            foreach (var td in tdCollection)
            {
                var attr = td.GetAttribute("class");
                switch (attr)
                {
                    case "last-name":
                        lastNameIndex = tdCollection.IndexOf(td);
                        lastNameIndexFound = true;
                        break;
                    case "email":
                        emailIndex = tdCollection.IndexOf(td);
                        emailIndexFound = true;
                        break;
                    case "web-site":
                        websiteIndex = tdCollection.IndexOf(td);
                        websiteIndexFound = true;
                        break;
                }
            }

            if (!lastNameIndexFound || !emailIndexFound || !websiteIndexFound) continue;
            var lastName = tdCollection[lastNameIndex];
            var email = tdCollection[emailIndex];
            var website = tdCollection[websiteIndex];
                
            if (lastName.Text == lastname && email.Text == emailaddress)
            {
                websiteTxt =  website.Text;
            }
        }
        return websiteTxt;
    }
}