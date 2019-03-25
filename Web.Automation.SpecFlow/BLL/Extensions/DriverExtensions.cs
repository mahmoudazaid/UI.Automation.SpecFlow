using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BLL.Extensions
{
    public static class DriverExtensions
    {
        public static IWebElement ScrollToElement(this IWebDriver driver, By elementLocator, int timeOutInSeconds)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            var jse = (IJavaScriptExecutor)driver;
            
            // presence in DOM           
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator)); //FIXME: was: presenceOfElementLocated
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(elementLocator));

            var element = driver.FindElement(elementLocator);
            // scrolling
            jse.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            return element;
        }
       
    }
}
