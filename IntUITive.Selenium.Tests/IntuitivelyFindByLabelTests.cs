namespace IntUITive.Selenium.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class IntuitivelyFindByLabelTests : BaseIntuitivelyTests
    {
        [Test]
        public void Find_WithChildlessLabel_ReturnsLabel()
        {
            var foundElement = Intuitively.Find("Just a label");
            Assert.That(foundElement.TagName, Is.EqualTo("label"));
            Assert.That(foundElement.Text, Is.EqualTo("Just a label"));
        }

        [Test]
        public void Find_WithOrphanedLabel_ReturnsNothing()
        {
            Assert.That(Intuitively.Find("Other questions"), Is.Null);
        }
    }
}
