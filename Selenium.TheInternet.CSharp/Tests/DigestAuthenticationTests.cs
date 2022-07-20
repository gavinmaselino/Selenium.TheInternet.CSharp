using Selenium.TheInternet.CSharp.PageObject;

namespace Selenium.TheInternet.CSharp.Tests;

public class DigestAuthenticationTests : SetupTeardown
{
    [Test]
    public void Adding_Credentials_And_Accept()
    {
        var httpProtocol = Protocol;
        var address = Uri + "digest_auth";
        const string user = "admin";
        const string pw = "admin";
        var context = new BaseContext(driver);
        context.SelectDigestAuthLink()
            .EnterCredentials(user, pw, httpProtocol, address)
            .AssertSuccessMessageIsDisplayed();
    }
}