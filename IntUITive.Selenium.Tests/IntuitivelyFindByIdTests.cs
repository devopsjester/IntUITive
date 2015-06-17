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
    }
}