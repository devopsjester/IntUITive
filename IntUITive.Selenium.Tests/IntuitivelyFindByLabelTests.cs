namespace IntUITive.Selenium.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class IntuitivelyFindByLabelTests : BaseIntuitivelyTests
    {
        #region Edge cases
        [Test]
        public void Find_WithNoTerm_Fails()
        {
            Action find = () => Intuitively.Find(null);
            find.ShouldThrow<ArgumentException>("parameter cannot be null or empty");
        }

        [Test]
        public void Find_WithEmptyTerm_Fails()
        {
            Action find = () => Intuitively.Find(string.Empty);
            find.ShouldThrow<ArgumentException>("parameter cannot be null or empty");
        }

        [Test]
        public void Find_WithUnidentifiableTerm_ReturnsNothing()
        {
            var element = Intuitively.Find("unidentifiable term");

            element.Should().BeNull("no element could be found with this term");
        } 
        #endregion

        #region Find element by text

        [Test]
        public void Find_WithChildlessLabel_ReturnsLabel()
        {
            var element = Intuitively.Find("This is a uniquely identified header");

            element.GetAttribute("id").Should().Be("uniqueId");
        }

        #endregion

    }
}

