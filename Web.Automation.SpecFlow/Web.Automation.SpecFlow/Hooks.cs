using BLL.Browser;
using BLL.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow
{
    [Binding]
    public sealed class Hooks
    {
        protected static string browserName = ConfigurationManager.AppSettings["browser"];

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.OpenBrowser(browserName);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
                ScreenShot.TakeScreenShot();
            SoftAssertions.AssertAll();
            Driver.CloseBrowser();
        }
    }
}
