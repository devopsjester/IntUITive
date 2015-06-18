using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.PhantomJS;

    [TestFixture]
    public class EdgeCaseTests : BaseIntuitivelyTests
    {
        [Test]
        public void Find_WithNoTerm_Fails()
        {
            Assert.That(() => Intuitively.Find(null), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void Find_WithEmptyTerm_Fails()
        {
            Assert.That(() => Intuitively.Find(""), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void Find_WithUnidentifiableTerm_ReturnsNothing()
        {
            var element = Intuitively.Find("unidentifiable term");

            Assert.That(element, Is.Null);
        }
    }
}

