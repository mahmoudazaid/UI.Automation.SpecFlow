using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BLL.Extensions
{
    public static class ElementExtensions
    {
        public static IWebElement InspectElement(this IWebDriver driver, By elementLocator)
        {
            ElementExtensions.WaitForItToBeVisible(elementLocator, 60);
            var element = driver.FindElement(elementLocator);
            return element;
        }

        public static void WaitForItToBeVisible(By element, int timeOutInSeconds)
        {
            var wait = new WebDriverWait(Browser.Driver.WebDriver, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }
    }
}
