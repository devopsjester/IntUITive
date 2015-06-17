using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    [TestFixture]
    public class EdgeCaseTests
    {
        [Test]
        public void Find_WithNoTerm_Fails()
        { 
            var intuitively = new Intuitively();

            Assert.That(() => intuitively.Find(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Find_WithEmptyTerm_Fails()
        {
            var intuitively = new Intuitively();

            Assert.That(() => intuitively.Find(""), Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void Find_WithUnidentifiableTerm_ReturnsNothing()
        {
            var intuitively = new Intuitively();

            var element = intuitively.Find("unidentifiable term");

            Assert.That(element, Is.Null);
        }
    }
}

