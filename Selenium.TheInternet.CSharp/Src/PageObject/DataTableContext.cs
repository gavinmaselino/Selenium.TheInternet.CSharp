using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.PageObject;

public class DataTableContext
{
    private IWebDriver driver;

    public DataTableContext(IWebDriver driver)
    {
        this.driver = driver;
    }
    
    private string IterateTable(string lastname, string due)
    {
        var table = driver.FindElement(By.Id("table1"));
        string websiteTxt = null;

        IList<IWebElement> trCollection = table.FindElements(By.CssSelector("tbody > tr"));

        foreach (var element in trCollection) 
        {
            IList<IWebElement> tdCollection = element.FindElements(By.CssSelector("td"));

            var lastNameColTxt = tdCollection[0].Text;
            var dueColTxt = tdCollection[3].Text;
            if (lastNameColTxt == lastname && dueColTxt == due)
            {
                /*
                IndexOf method used on a list<> gets the index position
                var rowIndex = trCollection.IndexOf(element);
                Console.WriteLine($"Row index for {lastNameColTxt} and {dueColTxt} is {rowIndex}");
                */
                
                foreach (var ele in tdCollection)
                {

                        if (ele.Text != "edit delete") continue;
                        var colIndex = tdCollection.IndexOf(ele);
                        websiteTxt = tdCollection[colIndex-1].Text;
                        //Console.WriteLine($"Link Text is {linkTxt}");
                        
                }
            }
            

        }

        return websiteTxt;
    }

    public void AssertLinkText(string lastname, string due, string expectedlinktext)
    {
        var iterationResult = IterateTable(lastname, due);
        
        Assert.That(iterationResult, Is.EqualTo(expectedlinktext));
        
    }
    
}