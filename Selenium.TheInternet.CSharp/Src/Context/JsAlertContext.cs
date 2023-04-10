using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.Extensions;

namespace Selenium.TheInternet.CSharp.Context;

public class JsAlertContext
{
    private IWebDriver driver;
    public JsAlertContext(IWebDriver driver)
    {
        this.driver = driver;
    }
    
    public JsAlertContext SelectJsAlertButton()
    {
        ClickButton("jsAlert", "Click for JS Alert");
        return this;
    }
    
    public JsAlertContext SelectJsConfirmButton()
    {
        ClickButton("jsConfirm", "Click for JS Confirm");
        return this;
    }
    
    public JsAlertContext SelectJsPromptButton()
    {
        ClickButton("jsPrompt", "Click for JS Prompt");
        return this;
    }
    public JsAlertContext ChooseOk()
    {
        var alertDialog = SwitchToAlertDialog();
        alertDialog.Accept();
        return this;
    }
    
    public JsAlertContext ChooseCancel()
    {
        var alertDialog = SwitchToAlertDialog();
        alertDialog.Dismiss(); 
        return this;
    }
    
    public JsAlertContext EnterText(string text)
    {
        var alertDialog = SwitchToAlertDialog();
        alertDialog.SendKeys(text); 
        return this;
    }

    private void ClickButton(string onClickValue,string textContent)
    {
        driver.FindElementWithAssociatedText($"li button[onclick='{onClickValue}()']", textContent).Click();
    }

    private IAlert SwitchToAlertDialog()
    {
        var alert = driver.SwitchTo().Alert();
        return alert;
    }
    

    public void AssertResultText(string expectedtext)
    {
        var txtParagraph = driver.FindElement(By.CssSelector("p#result")).Text;
        Assert.That(txtParagraph, Is.EqualTo(expectedtext));
    }
}