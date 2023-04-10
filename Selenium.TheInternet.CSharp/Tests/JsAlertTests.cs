using NUnit.Framework;
using Selenium.TheInternet.CSharp.Context;

namespace Selenium.TheInternet.CSharp.Tests;

public class JsAlertTests : SetupTeardown
{
    [Test]
    public void Closing_Alert_Displays_Text()
    {
        const string expectedText = "You successfully clicked an alert";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsAlertButton()
            .ChooseOk()
            .AssertResultText(expectedText);

    }

    [Test]
    public void Accepting_Confirmation_Displays_Ok_Text()
    {
        const string expectedText = "You clicked: Ok";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsConfirmButton()
            .ChooseOk()
            .AssertResultText(expectedText);
    }

    
    [Test]
    public void Cancelling_Confirmation_Displays_Cancel_Text()
    {
        const string expectedText = "You clicked: Cancel";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsConfirmButton()
            .ChooseCancel()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Entering_Prompt_Text_And_Confirming_Displays_That_Text()
    {
        const string enteredText = "This is a test";
        const string expectedText = "You entered: This is a test";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsPromptButton()
            .EnterText(enteredText)
            .ChooseOk()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Entering_Prompt_Text_But_Cancelling_Displays_Null_Text()
    {
        const string enteredText = "This is a test";
        const string expectedText = "You entered: null";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsPromptButton()
            .EnterText(enteredText)
            .ChooseCancel()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Entering_Nothing_In_Prompt_Dialog_And_Confirming_Displays_Empty_Text()
    {
        const string expectedText = "You entered:";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsPromptButton()
            .ChooseOk()
            .AssertResultText(expectedText);
    }
    
    [Test]
    public void Cancelling_Prompt_Dialog_Without_Entering_Text()
    {
        const string expectedText = "You entered: null";
        
        var context = new BaseContext(Driver);
        context.SelectJsAlertLink()
            .SelectJsPromptButton()
            .ChooseCancel()
            .AssertResultText(expectedText);
    }
}