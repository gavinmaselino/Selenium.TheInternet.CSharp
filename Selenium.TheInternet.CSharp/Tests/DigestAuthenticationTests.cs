using NUnit.Framework;
using Selenium.TheInternet.CSharp.Context;

namespace Selenium.TheInternet.CSharp.Tests;

public class DigestAuthenticationTests : SetupTeardown
{
    [Test]
    public void Adding_Credentials_And_Accept()
    {
        const string address = $"{Uri}digest_auth";
        const string user = "admin";
        const string pw = "admin";
        var context = new BaseContext(Driver);
        context.SelectDigestAuthLink()
            .EnterCredentials(user, pw, Protocol, address)
            .AssertSuccessMessageIsDisplayed();
    }
}