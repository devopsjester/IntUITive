using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace IntUITive.Selenium.Tests
{
    using System.Text;

    public abstract class BaseIntuitivelyTests
    {
        protected IWebDriver Driver;
        protected Intuitively Intuitively;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Driver = new PhantomJSDriver
            {
                Url = TestSample.UriFromFile("UniqueIdHeader.html")
            };
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(4000));

            Intuitively = new Intuitively(Driver);

        }

        [TestFixtureTearDown]
        public void FixtureTeardown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}