using Selenium.TheInternet.CSharp.PageObject;

namespace Selenium.TheInternet.CSharp.Tests;

public class JSAlertTests : SetupTeardown
{
    [Test]
    public void Closing_Alert_Displays_Text()
    {
        var expectedText = "You successfully clicked an alert";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSAlertButton()
            .ChooseOk()
            .AssertResultText(expectedText);

    }

    [Test]
    public void Accepting_Confirmation_Displays_Ok_Text()
    {
        var expectedText = "You clicked: Ok";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSConfirmButton()
            .ChooseOk()
            .AssertResultText(expectedText);
    }

    
    [Test]
    public void Cancelling_Confirmation_Displays_Cancel_Text()
    {
        var expectedText = "You clicked: Cancel";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSConfirmButton()
            .ChooseCancel()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Entering_Prompt_Text_And_Confirming_Displays_That_Text()
    {
        var enteredText = "This is a test";
        var expectedText = "You entered: This is a test";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSPromptButton()
            .EnterText(enteredText)
            .ChooseOk()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Entering_Prompt_Text_But_Cancelling_Displays_Null_Text()
    {
        var enteredText = "This is a test";
        var expectedText = "You entered: null";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSPromptButton()
            .EnterText(enteredText)
            .ChooseCancel()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Entering_Nothing_In_Prompt_Dialog_And_Confirming_Displays_Empty_Text()
    {
        var expectedText = "You entered:";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSPromptButton()
            .ChooseOk()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Cancelling_Prompt_Dialog_Without_Entering_Text()
    {
        var expectedText = "You entered: null";
        
        var context = new BaseContext(driver);
        context.SelectJSAlertLink()
            .SelectJSPromptButton()
            .ChooseCancel()
            .AssertResultText(expectedText);
    }
}