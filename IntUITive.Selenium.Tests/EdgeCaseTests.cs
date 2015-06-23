using System;
using FluentAssertions;
using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    public class EdgeCaseTests
    {
        [Test]
        public void Find_WithNoTerm_Fails()
        {
            Action find = () => Context.Intuitively.Find(null);
            find.ShouldThrow<ArgumentException>("parameter cannot be null or empty");
        }

        [Test]
        public void Find_WithEmptyTerm_Fails()
        {
            Action find = () => Context.Intuitively.Find(string.Empty);
            find.ShouldThrow<ArgumentException>("parameter cannot be null or empty");
        }

        [Test]
        public void Find_WithUnidentifiableTerm_ReturnsNothing()
        {
            var element = Context.Intuitively.Find("unidentifiable term");

            element.Should().BeNull("no element could be found with this term");
        }
    }
}