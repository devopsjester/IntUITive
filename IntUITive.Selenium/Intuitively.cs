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

            var requestedIndex = RequestedIndexInTerm(term);
            var candidates = FindByText(term);

            var bestMatches = candidates.WithShortestText();

            return requestedIndex == 0 ?
                bestMatches.FirstOrDefault() :
                bestMatches.ToArray()[requestedIndex-1];
        }

        private int RequestedIndexInTerm(string term)
        {
            var index = 0;
            const string indexPattern = @".+\[(?<index>\d+)\]$";
            var match = Regex.Match(term, indexPattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                index = int.Parse(match.Groups["index"].Value);
            }

            return index;
        }

        private IEnumerable<IWebElement> FindByText(string term)
        {
            return from e in _allElementsOnPage
                where Regex.IsMatch(e.Text, term, RegexOptions.IgnoreCase)
                select e;
        }
    }
}