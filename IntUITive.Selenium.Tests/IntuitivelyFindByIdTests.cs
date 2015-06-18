using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    [TestFixture]
    public class IntuitivelyFindByIdTests : BaseIntuitivelyTests
    {
        [Test]
        public void Find_WithIdAsTerm_ReturnsElement()
        {
            var element = Intuitively.Find("uniqueId");

            Assert.That(element.GetAttribute("id"), Is.EqualTo("uniqueId"));
        }
        
        [Test]
        public void Find_WithCaseInsensitiveId_ReturnsElement()
        {
            var element = Intuitively.Find("UNIQUEID");

            Assert.That(element.GetAttribute("id"), Is.EqualTo("uniqueId"));
        }

        [Test]
        public void Find_WithPartialMatch_ReturnsElement()
        {
            var element = Intuitively.Find("unique");

            Assert.That(element.GetAttribute("id"), Is.EqualTo("uniqueId"));
        }

        [Test]
        public void Find_WithMultipleMatches_ReturnsFirstElement()
        {
            var element = Intuitively.Find("special");

            Assert.That(element.GetAttribute("id"), Is.EqualTo("specialCase1"));
        }
    }
}