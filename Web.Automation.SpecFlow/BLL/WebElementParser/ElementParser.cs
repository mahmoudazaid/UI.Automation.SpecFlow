using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;

namespace BLL.WebElementParser
{
    public class ElementParser
    {
        public Dictionary<string, By> Elements { set; get; }
        public List<WebElement> AllElementDetailed { set; get; }
        public ElementParser(string fileName)
        {

            Elements = new Dictionary<string, By>();
            AllElementDetailed = DeserializeWebElements(fileName);
            AddElementsToDictionary(AllElementDetailed);
        }
        public By GetElementByName(string name)
        {
            return Elements[name];
        }
        private void AddElementsToDictionary(IEnumerable<WebElement> webElementsItems)
        {
            foreach (var element in webElementsItems)
            {
                var locator = LocatorFactory.CreateLocator(element);
                Elements.Add(element.Name, locator);
            }
        }
        private static List<WebElement> DeserializeWebElements(string fileName)
        {
            var directory = AppDomain.CurrentDomain.RelativeSearchPath ??
                                    AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(directory, "ObjectRepository", fileName);
            var file = File.ReadAllText(filePath);
            var elements = JsonConvert.DeserializeObject<List<WebElement>>(file);
            return elements;
        }

        public WebElement Get_ElementDetails(string name)
        {
            WebElement myelement = new WebElement();
            foreach (var element in AllElementDetailed)
            {
                if (element.Name == name)
                {
                    myelement = element;
                    break;
                }
            }
            return myelement;

        }
    }
}

