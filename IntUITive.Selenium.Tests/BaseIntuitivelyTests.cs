using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace IntUITive.Selenium.Tests
{
    public class BaseIntuitivelyTests
    {
        protected Intuitively Intuitively;

        [SetUp]
        public void Setup()
        {
            var sampleFolder = new Uri(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                             "TestSamples\\SimplePage.html")
                );
            IWebDriver driver = new PhantomJSDriver();
            driver.Url = sampleFolder.AbsoluteUri;
            Intuitively = new Intuitively(driver);
        }
    }
}