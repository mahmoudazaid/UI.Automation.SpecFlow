using BLL.Assertions;
using BLL.Browser;
using BLL.Extensions;
using FluentAssertions;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Utilities
{
    public class SoftAssertions
    {
        public static List<SingleAssert> _verifications = new List<SingleAssert>();

        public static void ShouldSee(string expectedText, string actualText)
        {            
            _verifications.Add(new SingleAssert("Comparing Text",expectedText, actualText));
        }

        public static void Add(string message, string expected, string actual)
        {
            _verifications.Add(new SingleAssert(message, expected, actual));
        }

        public static void Add(string message, bool expected, bool actual)
        {
            Add(message, expected.ToString(), actual.ToString());
        }

        public static void Add(string message, int expected, int actual)
        {
            Add(message, expected.ToString(), actual.ToString());
        }

        public static void AddTrue(string message, bool actual)
        {
            _verifications
                .Add(new SingleAssert(message, true.ToString(), actual.ToString()));
        }

        public static void AssertAll()
        {
            var failed = _verifications.Where(v => v.Failed).ToList();
            failed.Should().BeEmpty();
        }        
    }
}
