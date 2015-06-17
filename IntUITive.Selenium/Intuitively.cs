using System;
using System.Linq;
using OpenQA.Selenium;

namespace IntUITive.Selenium
{
    public class Intuitively
    {
        private readonly IWebDriver _driver;

        public Intuitively(IWebDriver driver)
        {
            _driver = driver;
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
            var possibleElements = _driver.FindElements(By.Id(term));

            return possibleElements.FirstOrDefault();
        }
    }

}