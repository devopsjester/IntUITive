namespace IntUITive.Selenium.Tests
{
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    public abstract class BaseTests
    {
        protected IWebDriver Driver;

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        protected void SetupWebDriver()
        {
            Driver = new PhantomJSDriver
            {
                Url = TestSample.UriFromFile("UniqueIdHeader.html")
            };
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(4000));
        }
    }
}