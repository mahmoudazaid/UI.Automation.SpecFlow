using BLL.Browser;
using BLL.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Actions
{
    public class ElementActions
    {
        public static void ClickLink(By _link)
        {
            Driver.WebDriver.ScrollToElement(_link, 10);
            IWebElement link = Driver.WebDriver.InspectElement(_link);
            link.Click();
        }
        public void ClickButton(By _button)
        {
            Driver.WebDriver.ScrollToElement(_button, 10);
            IWebElement button = Driver.WebDriver.InspectElement(_button);
            button.Click();
        }
    }
}
