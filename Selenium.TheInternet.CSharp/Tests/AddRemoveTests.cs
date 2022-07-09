using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.PageObject;

namespace Selenium.TheInternet.CSharp.Tests;

[TestFixture]
public class AddRemoveTests : SetupTeardown
{
    
    [Test]
    public void Delete_Button_Created_And_Count_Is_One()
    {
        var context = new BaseContext(driver);
        
        context.SelectAddRemoveElements()
            .CreateDeleteButtons(1)
            .AssertDeleteButtonCountIsEqualTo(1);

    }
    
  
   

    
}