using AutomationFramework.WebElementParser;
using BLL.Actions;
using BLL.Browser;
using BLL.Extensions;
using OpenQA.Selenium;
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
            try
            {
                var _link = _parser.GetElementByName(link);
                ElementActions.ClickLink(_link);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        }

        [When(@"Choose ""(.*)"" file to upload")]
        public void WhenChooseFileToUpload(string _file)
        {
            var _uploadButton = _parser.GetElementByName("Choose file");
            ElementActions.UploadFile(_uploadButton, _file);
        }

        [When(@"Click on ""(.*)"" button")]
        public void WhenClickOnButton(string _button)
        {
            var _uploadButton = _parser.GetElementByName(_button);
            ElementActions.ClickButton(_uploadButton);
        }

    }
}
