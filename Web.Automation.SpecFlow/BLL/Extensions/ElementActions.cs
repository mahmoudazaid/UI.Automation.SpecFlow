using BLL.Browser;
using BLL.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static void ClickButton(By _button)
        {
            Driver.WebDriver.ScrollToElement(_button, 10);
            IWebElement button = Driver.WebDriver.InspectElement(_button);
            button.Click();
        }

        public static void UploadFile(By _uploadButton, string _fileName)
        {
            var directory = AppDomain.CurrentDomain.RelativeSearchPath ??
                                 AppDomain.CurrentDomain.BaseDirectory;
            var file_Path = Path.Combine(directory, "Attachments", _fileName);            
            Driver.WebDriver.ScrollToElement(_uploadButton, 10);
            Driver.WebDriver.FindElement(_uploadButton).SendKeys(file_Path);
        }

        public static void SelectCheckBox(By _checkbox )
        {
            Driver.WebDriver.ScrollToElement(_checkbox, 10);
            IWebElement checbox = Driver.WebDriver.InspectElement(_checkbox);
            checbox.Click();
        }
    }
}
