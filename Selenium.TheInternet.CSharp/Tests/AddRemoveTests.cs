using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.TheInternet.CSharp.Context;

namespace Selenium.TheInternet.CSharp.Tests;

[TestFixture]
public class AddRemoveTests : SetupTeardown
{
    [Test]
    public void Delete_Button_Created_And_Count_Is_One()
    {
        var context = new BaseContext(Driver);
        
        context.SelectAddRemoveElements()
            .CreateDeleteButtons(1)
            .AssertDeleteButtonCountIsEqualTo(1);
    }
    
  
   

    
}