using BLL.Browser;
using OpenQA.Selenium;
using System;
using System.IO;

namespace BLL.Utilities
{
    public class ScreenShot
    {
        public static void TakeScreenShot()
        {
            var takesScreenshot = Driver.WebDriver as ITakesScreenshot;
            string ScreenShootPath = Path.Combine(Directory.GetCurrentDirectory() + "\\ScreenShoots");
            CreateFolder(ScreenShootPath);
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(ScreenShootPath, Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);
                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }

        public static void CreateFolder(string path)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}