using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace BLL.Browser
{
    public class Driver
    {
        public static IWebDriver WebDriver;

        public static IWebDriver OpenBrowser(string browserName)
        {
            WebDriver = null;
            switch (browserName)
            {
                case "Firefox":

                    if (WebDriver == null)
                    {
                        WebDriver = new FirefoxDriver();
                    }
                    break;                

                case "Chrome":

                    if (WebDriver == null)
                    {                        
                        WebDriver = new ChromeDriver();
                    }

                    break;

            }
            WebDriver.Manage().Window.Maximize();
            return WebDriver;
        }
        public static void Visit(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public static void CloseBrowser()
        {
            WebDriver.Quit();
            WebDriver = null;            
        }
    }
}
