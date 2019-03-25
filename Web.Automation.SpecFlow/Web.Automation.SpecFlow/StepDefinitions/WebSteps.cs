using AutomationFramework.WebElementParser;
using BLL.Actions;
using BLL.Browser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow
{
    [Binding]
    public sealed class SharedSteps
    {
        protected static string baseURL = ConfigurationManager.AppSettings["URL"];
        private readonly ParsersManager _parser = new ParsersManager("Home.json");


        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I am on Home Page")]
        public void GivenIAmOnHomePage()
        {
            Driver.Visit(baseURL);
        }

        [When(@"Click on ""(.*)"" Link")]
        public void WhenClickOnLink(string link)
        {
            var _link = _parser.GetElementByName(link);
            ElementActions.ClickLink(_link);
        }


    }
}
