using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace IntUITive.Selenium
{
    public class Intuitively
    {
        private readonly IWebDriver _driver;
        private readonly ReadOnlyCollection<IWebElement> _allElementsOnPage;

        public Intuitively(IWebDriver driver)
        {
            _driver = driver;
            _allElementsOnPage = _driver.FindElements(By.XPath("//*"));
        }

        public IWebElement Find(string term)
        {
            if (term == null)
            {
                throw new ArgumentNullException("term", "parameter cannot be empty or null.");
            }
            if (term == string.Empty)
            {
                throw new ArgumentException("parameter cannot be empty or null.", "term");
            }

            var foundElement = TryFindById(term);

            return foundElement;
        }

        private IWebElement TryFindById(string term)
        {
            var pattern = string.Format("{0}", term);
            var possibleElements = from e in _allElementsOnPage
                                   let elementAttribute = e.GetAttribute("id")
                                   where Regex.IsMatch(elementAttribute, pattern, RegexOptions.IgnoreCase)
                                   select e;

            return possibleElements.FirstOrDefault();
        }
    }

}