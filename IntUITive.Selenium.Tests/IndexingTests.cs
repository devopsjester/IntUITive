using FluentAssertions;
using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    public class IndexingTests
    {
        [Test]
        public void Find_WithTwoElementWithSameText_ReturnsFirst()
        {
            var element = Context.Intuitively.Find("Same text header");

            element.GetAttribute("id").Should().Be("headerId1");
        }

        [Test]
        public void Find_WithIndexOfOne_ReturnsFirst()
        {
            var element = Context.Intuitively.Find("Same text header[1]");

            element.GetAttribute("id").Should().Be("headerId1");
        }

        [Test]
        public void Find_WithIndexOfTwo_ReturnsSecond()
        {
            var element = Context.Intuitively.Find("Same text header[2]");

            element.GetAttribute("id").Should().Be("headerId2");
        }

        [Test]
        public void Find_WithIndexOfNegOne_ReturnsLast()
        {
            var element = Context.Intuitively.Find("Same text header[-1]");

            element.GetAttribute("id").Should().Be("headerId3");
        }

        [Test]
        public void Find_WithIndexOfNegTwo_ReturnsSecondToLast()
        {
            var element = Context.Intuitively.Find("Same text header[-2]");

            element.GetAttribute("id").Should().Be("headerId2");
        }
    }
}