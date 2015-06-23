namespace IntUITive.Selenium.Tests
{
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    [SetUpFixture]
    public class Context
    {
        public static IWebDriver Driver { get; private set; }
        public static Intuitively Intuitively { get; private set; }

        [SetUp]
        public void Setup()
        {
            Driver = new PhantomJSDriver
            {
                Url = TestSample.UriFromFile("UniqueIdHeader.html")
            };
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(4000));
            
            Intuitively = new Intuitively(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}