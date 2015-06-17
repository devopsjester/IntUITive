using NUnit.Framework;

namespace IntUITive.Selenium.Tests
{
    public class BaseIntuitivelyTests
    {
        protected Intuitively Intuitively;

        [SetUp]
        public void Setup()
        {
            Intuitively = new Intuitively();
        }
    }
}