namespace IntUITive.Selenium.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class IntuitivelyFindByLabelTests : BaseIntuitivelyTests
    {
        /// <summary>
        /// Find_s the with label text_ returns labeled element.
        /// </summary>
        [Test]
        public void Find_WithLabelText_ReturnsLabeledElement()
        {
            Assert.That(Intuitively.Find("First Name").GetAttribute("id"),
                Is.EqualTo("firstName"));
        }

        [Test]
        public void Find_WithOrphanedLabel_ReturnsNothing()
        {
            Assert.That(Intuitively.Find("Orphan"), Is.Null);
        }

        [Test]
        public void Find_WithLabelForPartiallyIdentified_ReturnsLabel()
        {
            Assert.That(Intuitively.Find("gender").Text, Is.EqualTo("Gender:"));
        }
    }
}