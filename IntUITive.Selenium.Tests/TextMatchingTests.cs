using FluentAssertions;
using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    public class TextMatchingTests
    {
        [Test]
        public void Find_WithExactTerm_ReturnsElement()
        {
            var element = Context.Intuitively.Find("This is a uniquely identified header");

            element.GetAttribute("id").Should().Be("uniqueId");
        }

        [Test]
        public void Find_IsCaseInsensitive()
        {
            var element = Context.Intuitively.Find("this is a uniquely identified header");
            
            element.GetAttribute("id").Should().Be("uniqueId");
        }

        [Test]
        public void Find_WithPartialTextTerm_ReturnsBestMatchingElement()
        {
            var element = Context.Intuitively.Find("uniquely identified");

            element.GetAttribute("id").Should().Be("uniqueId");   
        }
    }
}