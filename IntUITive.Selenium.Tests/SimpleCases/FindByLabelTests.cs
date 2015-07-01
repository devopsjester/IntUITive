namespace IntUITive.Selenium.Tests.SimpleCases
{
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class FindByLabelTests
    {
        [Test]
        public void Find_ChildlessAndBrotherlessLabel_ReturnsLabel()
        {
            var element = Context.Intuitively.Find("label without child input");

            element.Text.Should().Be("Label without child input");
        }

        [Test]
        public void Find_WithOrphanLabel_ReturnsLabel()
        {
            var element = Context.Intuitively.Find("orphan label");

            element.GetAttribute("for").Should().Be("otherStuff");
        }
    }
}