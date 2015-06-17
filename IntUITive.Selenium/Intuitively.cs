using System;
using OpenQA.Selenium;

namespace IntUITive.Selenium
{
    public class Intuitively
    {
        public IWebElement Find(string term)
        {
            throw new ArgumentNullException("term", "parameter cannot be empty or null.");
        }
    }
}