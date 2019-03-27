using BLL.Browser;
using BLL.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Threading;

namespace BLL.Extensions
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

        public static void SelectCheckBox(By _checkbox)
        {
            Driver.WebDriver.ScrollToElement(_checkbox, 10);
            IWebElement checbox = Driver.WebDriver.InspectElement(_checkbox);
            checbox.Click();
        }

        public static void DragAndDrop(By _source, By _target)
        {
            try
            {
                Thread.Sleep(2000);
                Actions actionBuilder = new Actions(Driver.WebDriver);
                Driver.WebDriver.ScrollToElement(_source, 10);
                IWebElement source = Driver.WebDriver.InspectElement(_source);
                IWebElement target = Driver.WebDriver.InspectElement(_target);                
                actionBuilder.DragAndDrop(source, target).Build().Perform();                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception ******" + ex.ToString());

            }

        }
    }
}
