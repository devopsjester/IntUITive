using System;
using OpenQA.Selenium;

namespace IntUITive.Selenium
{
    public class Intuitively
    {
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
            
            return null;
        }
    }
}