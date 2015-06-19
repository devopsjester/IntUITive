using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace IntUITive.Selenium
{
    using System.Security.Cryptography;

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

            var foundElement =
                FindElementById(term) ??
                FindElementByLabelFor(term);

            return foundElement;
        }

        private IWebElement FindElementByLabelFor(string term)
        {
            var labelElement = FindElementByText(term);
            var element = labelElement == null ? null : FindElementById(labelElement.GetAttribute("for"));
            return element;
        }

        private IWebElement FindElementByText(string term)
        {
            var possibleElements = from e in _allElementsOnPage
                                   let elementAttribute = e.Text
                                   where Regex.IsMatch(elementAttribute, term, RegexOptions.IgnoreCase)
                                   select e;

            var webElements = possibleElements as IWebElement[] ?? possibleElements.ToArray();
            
            if (!webElements.Any())
            {
                return null;
            }
            var element = webElements.
                Aggregate(
                    (curMin, x) =>
                        (curMin == null || (x.Text == null ? int.MaxValue : x.Text.Length) < curMin.Text.Length
                            ? x
                            : curMin));

            return element;
        }

        private IWebElement FindElementById(string term)
        {
            return FindElementByAttribute("id", term);
        }

        private IWebElement FindElementByAttribute(string attributeName, string term)
        {
            var possibleElements = from e in _allElementsOnPage
                                   let elementAttribute = e.GetAttribute(attributeName)
                                   where elementAttribute.Equals(term, StringComparison.OrdinalIgnoreCase)
                                   select e;

            return possibleElements.FirstOrDefault();
        }
    }
}