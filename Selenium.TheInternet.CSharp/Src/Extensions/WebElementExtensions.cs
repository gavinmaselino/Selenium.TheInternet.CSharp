using OpenQA.Selenium;

namespace Selenium.TheInternet.CSharp.Extensions;

public static class WebElementExtensions
{
    /// <summary>
 /// Returns the first element in the list that matches a combination of the CSS Selector value and the element's inner text.
 /// </summary>
 /// <param name="webDriver"></param>
 /// <param name="elementSelector"></param>
 /// <param name="textContent"></param>
 /// <returns>The IWebElement value</returns>
 /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static IWebElement FindElementWithAssociatedText(this IWebDriver webDriver, string elementSelector, string textContent)
    {
        var targetElement = webDriver.FindElements(By.CssSelector(elementSelector)).FirstOrDefault(e => e.Text == textContent);
        if (targetElement == null)
        {
            throw new ArgumentOutOfRangeException($"Element at selector '{elementSelector}' with text content '{textContent}' does not exist");
        }
        return targetElement;
    }
}