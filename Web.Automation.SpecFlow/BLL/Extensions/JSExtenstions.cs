using BLL.Browser;
using OpenQA.Selenium;

namespace BLL.Extensions
{
    public static class JSExtenstions
    {
        public static string ExecuteJs(string script)
        {
            var x = ((IJavaScriptExecutor)Driver.WebDriver).ExecuteScript(script);
            if (x != null)
                return x.ToString();
            return null;
        }
    }
}
