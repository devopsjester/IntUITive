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

            var search = new Search(term);
            var candidates = FindByText(search.Term);

            var bestMatches = candidates.WithShortestText().ToArray();

            if (!bestMatches.Any())
            {
                return null;
            }

            IWebElement bestMatch;
            if (search.RequestedIndex == 0)
            {
                bestMatch = bestMatches.First();
            }
            else if (search.RequestedIndex > 0)
            {
                bestMatch = bestMatches[search.RequestedIndex - 1];
            }
            else
            {
                bestMatch = bestMatches[bestMatches.Count() + search.RequestedIndex];
            }

            return bestMatch;
        }

        private IEnumerable<IWebElement> FindByText(string term)
        {
            return from e in _allElementsOnPage
                where Regex.IsMatch(e.Text, term, RegexOptions.IgnoreCase)
                select e;
        }
    }

    internal class Search
    {
        public int RequestedIndex { get; private set; }
        public string Term { get; private set; }

        public Search(string term)
        {
            ParseTermString(term);
        }

        private void ParseTermString(string term)
        {
            int foundIndex;
            const string indexPattern = @"^(?<term>[^\[]+)(?:\[(?<index>-?\d+)\])?$";
            var match = Regex.Match(term, indexPattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                throw new ArgumentException(string.Format("invalid search term: {0}", term), "term");
            }

            Term = match.Groups["term"].Value;
            RequestedIndex = int.TryParse(match.Groups["index"].Value, out foundIndex)
                ? foundIndex
                : 0;
        }
    }
}