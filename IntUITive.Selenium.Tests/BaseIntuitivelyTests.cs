using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace IntUITive.Selenium.Tests
{
    using System.Text;

    public abstract class BaseIntuitivelyTests : BaseTests
    {
        protected Intuitively Intuitively;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            SetupWebDriver();

            Intuitively = new Intuitively(Driver);
        }
    }
}