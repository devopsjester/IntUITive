using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    [TestFixture]
    public class IntuitivelyFindByIdTests : BaseIntuitivelyTests
    {
        [Test]
        public void Find_WithIdAsTerm_ReturnsSingleElement()
        {
            var element = Intuitively.Find("uniqueId");

            Assert.That(element.GetAttribute("id"), Is.EqualTo("uniqueId"));
        }

        [Test]
        public void Find_WithCaseInsensitiveId_ReturnsSingleElement()
        {
            var element = Intuitively.Find("UNIQUEID");

            Assert.That(element.GetAttribute("id"), Is.EqualTo("uniqueId"));
        }
    }
}