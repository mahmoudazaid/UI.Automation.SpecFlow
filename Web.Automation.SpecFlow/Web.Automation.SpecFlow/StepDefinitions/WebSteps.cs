using AutomationFramework.WebElementParser;
using BLL.Browser;
using BLL.Extensions;
using BLL.Utilities;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace Web.Automation.SpecFlow
{
    [Binding]
    public sealed class SharedSteps
    {
        private static string baseURL = ConfigurationManager.AppSettings["URL"];
        private readonly ParsersManager _parser = new ParsersManager("Home.json");


        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I am on Home Page")]
        public void GivenIAmOnHomePage()
        {
            Driver.Visit(baseURL);
        }

        [When(@"[Cc]lick on ""(.*)"" Link")]
        public void WhenClickOnLink(string link)
        {
            try
            {
                var _link = _parser.GetElementByName(link);
                SEActions.ClickLink(_link);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        }

        [When(@"[Cc]hoose ""(.*)"" file to upload")]
        public void WhenChooseFileToUpload(string _file)
        {
            var _uploadButton = _parser.GetElementByName("Choose file");
            SEActions.UploadFile(_uploadButton, _file);
        }

        [When(@"[Cc]lick on ""(.*)"" button")]
        public void WhenClickOnButton(string _button)
        {
            var _uploadButton = _parser.GetElementByName(_button);
            SEActions.ClickButton(_uploadButton);
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string _text)
        {
            var _element = _parser.GetElementByName(_text);
            Driver.WebDriver.ScrollToElement(_element, 10);
            IWebElement element = Driver.WebDriver.InspectElement(_element);
            string elementText = element.Text;            
            SoftAssertions.ShouldSee(_text, elementText);           
        }
        [Then(@"[Cc]heck ""(.*)"" downloaded successfuly")]
        public void ThenCheckDownloadedSuccessfuly(string _filename)
        {
            Thread.Sleep(3000);
            var checker=FilesManager.FileDownloaded(_filename);
            SoftAssertions.AddTrue("The file should be deleted", checker);
        }

        [Then(@"[Dd]elete ""(.*)"" file")]
        public void ThenDeleteFile(string _filename)
        {
            FilesManager.DeleteFile(_filename);
        }
        [When(@"([Cc]heck|[Uu]n[Cc]heck) on ""(.*)"" checkbox")]
        public void WhenSelectCheckbox(string _checkbox)
        {
            var checkbox = _parser.GetElementByName(_checkbox);
            SEActions.SelectCheckBox(checkbox);
        }

        [When(@"[Dd]rag ""(.*)"" and drop to ""(.*)""")]
        public void WhenDragAnndDropTo(string _source, string _target)
        {
            var source = _parser.GetElementByName(_source);
            var target = _parser.GetElementByName(_target);
            SEActions.DragAndDrop(source, target);
        }


    }
}
