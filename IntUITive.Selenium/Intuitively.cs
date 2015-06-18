using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace IntUITive.Selenium
{
    public class Intuitively
    {
        private readonly ReadOnlyCollection<IWebElement> _allElementsOnPage;

        public Intuitively(IWebDriver driver)
        {
            _allElementsOnPage = driver.FindElements(By.XPath("//*"));
        }

        public IWebElement Find(string term)
        {
            if (term.IsNullOrWhiteSpace())
            {
                throw new ArgumentException("parameter cannot be empty or null.", "term");
            }

            var foundElement = FindElementById(term);

            return foundElement;
        }

        private IWebElement FindElementByAttribute(string attributeName, string term)
        {
            var pattern = string.Format("{0}", term);
            var possibleElements = from e in _allElementsOnPage
                let elementAttribute = e.GetAttribute(attributeName)
                where Regex.IsMatch(elementAttribute, pattern, RegexOptions.IgnoreCase)
                select e;

            return possibleElements.FirstOrDefault();
        }

        private IWebElement FindElementById(string term)
        {
            return FindElementByAttribute("id", term);
        }
    }
}