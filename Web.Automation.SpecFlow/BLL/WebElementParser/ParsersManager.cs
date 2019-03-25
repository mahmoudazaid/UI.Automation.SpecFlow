using BLL.WebElementParser;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace AutomationFramework.WebElementParser
{
    public class ParsersManager
    {
        private IList<ElementParser> _parsers;

        public ParsersManager(params string[] fileNames)
        {
            Initialize(fileNames);
        }

        private void Initialize(IEnumerable<string> fileNames)
        {
            _parsers = new List<ElementParser>();
            foreach (var filename in fileNames)
                _parsers.Add(new ElementParser(filename));
        }


        public By GetElementByName(string name)
        {
            foreach (var parser in _parsers)
            {
                var element = parser.GetElementByName(name);
                if (element != null)
                    return element;
            }
            return null;
        }
        public WebElement Get_ElementDetails(string name)
        {
            foreach (var parser in _parsers)
            {
                WebElement element = parser.Get_ElementDetails(name);
                if (element.Name == name)
                    return element;
            }
            return null;

        }

    }
}
