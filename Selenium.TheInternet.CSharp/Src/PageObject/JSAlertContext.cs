using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.PageObject;

public class JSAlertContext
{
    private IWebDriver driver;
    public JSAlertContext(IWebDriver driver)
    {
        this.driver = driver;
    }

    private IWebElement btnJSAlert => driver.FindElement(By.XPath("//button[@onclick='jsAlert()']"));
    private IWebElement btnJSConfirm => driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']"));
    
    private IWebElement btnJSPrompt => driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']"));
    private IWebElement paragraphElement => driver.FindElement(By.CssSelector("p#result"));
    
    
    public JSAlertContext SelectJSAlertButton()
    {
        btnJSAlert.Click();
        return this;
    }
    
    public JSAlertContext SelectJSConfirmButton()
    {
        btnJSConfirm.Click();
        return this;
    }
    
    public JSAlertContext SelectJSPromptButton()
    {
        btnJSPrompt.Click();
        return this;
    }
    
    public JSAlertContext ChooseOk()
    {
        var alertDialog = SwitchToAlertDialog();
        alertDialog.Accept();
        return this;
    }
    
    public JSAlertContext ChooseCancel()
    {
        var alertDialog = SwitchToAlertDialog();
        alertDialog.Dismiss(); 
        return this;
    }
    
    public JSAlertContext EnterText(string text)
    {
        var alertDialog = SwitchToAlertDialog();
        alertDialog.SendKeys(text); 
        return this;
    }

    private IAlert SwitchToAlertDialog()
    {
        var alert = driver.SwitchTo().Alert();
        return alert;
    }
    

    public void AssertResultText(string expectedtext)
    {
        var txtParagraph = paragraphElement.Text;
        Assert.That(txtParagraph, Is.EqualTo(expectedtext));
    }
    
    
    
}