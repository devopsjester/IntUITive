namespace IntUITive.Selenium
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
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

            var candidates = FindByLabel(term);
            return candidates.FirstOrDefault();
        }

        private IEnumerable<IWebElement> FindByLabel(string term)
        {
            var texts = _allElementsOnPage.Select(e => e.Text);
            Console.WriteLine(texts.Count());

            var elements = from e in _allElementsOnPage
                           where e.TagName == "label"
                                 && e.Text.Resembles(term)
                           select (e);

            return elements;
        }
    }
}