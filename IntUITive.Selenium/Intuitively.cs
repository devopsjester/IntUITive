namespace IntUITive.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using OpenQA.Selenium;

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

            var candidates = FindByText(term);

            var bestMatches = candidates.WithShortestText();

            return bestMatches.FirstOrDefault();
        }

        private IEnumerable<IWebElement> FindByText(string term)
        {
            return from e in _allElementsOnPage
                where Regex.IsMatch(e.Text, term, RegexOptions.IgnoreCase)
                select e;
        }
    }

    static class EnumerableExtensions
    {
        public static IEnumerable<IWebElement> WithShortestText(this IEnumerable<IWebElement> elements)
        {
            var elementsArray = elements as IWebElement[] ?? elements.ToArray();
            if (!elementsArray.Any())
            {
                return elementsArray;
            }
            var shortestElement = elementsArray.
                Aggregate(
                    (curMin, x) =>
                        (curMin == null || (x.Text == null ? int.MaxValue : x.Text.Length) < curMin.Text.Length
                            ? x
                            : curMin));

            return elementsArray.Where(e => e.Text.Length == shortestElement.Text.Length);
        } 
    }
}