using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace IntUITive.CodedUI.Tests
{
    using System.IO;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    [DeploymentItem(@"TestPages\", "TestPages")]
    public class CodedUIBasedIntuitiveFindTest
    {
        [TestMethod]
        public void Find_WithNoTerm_ShouldFail()
        {
            var intuitively = Intuitively.Search(TestHelper.GetBrowserWindowFor("PageWithTextBox.html"));

            Action findNull = () => intuitively.Find(null);

            findNull.ShouldThrow<ArgumentNullException>("nothing comes from nothing");

        }

        [TestMethod]
        public void Find_WithEmptyString_ShouldFail()
        {
            var intuitively = Intuitively.Search(TestHelper.GetBrowserWindowFor("PageWithTextBox.html"));

            Action findEmptyString = () => intuitively.Find(String.Empty);

            findEmptyString.ShouldThrow<ArgumentException>("empty term means empty hands", "term");
        }

        [TestMethod]
        public void Find_WithUnknownTerm_ReturnsNull()
        {
            var intuitively = Intuitively.Search(TestHelper.GetBrowserWindowFor("PageWithTextBox.html"));

            intuitively.Find("unknown control").Should().BeNull("it isn't on the page");
        }

        [TestMethod]
        public void Find_WithElementId_ReturnsHtmlControl()
        {
            var intuitively = Intuitively.Search(TestHelper.GetBrowserWindowFor("PageWithTextBox.html"));

            var firstNameInputElement = intuitively.Find("firstName");

            firstNameInputElement.Should().NotBeNull("it is there").
                And.BeOfType<HtmlControl>("it is an HTML input element");
            firstNameInputElement.Id.Should().Be("firstName", "it should find the first name textbox");
        }

        [TestMethod]
        public void Find_WithPlaceHolder_ReturnsHtmlControl()
        {
            var intuitively = Intuitively.Search(TestHelper.GetBrowserWindowFor("PageWithTextBox.html"));

            var firstNameInputElement = intuitively.Find("First Name");

            firstNameInputElement.Should().NotBeNull("it is there").
                And.BeOfType<HtmlControl>("it is an HTML input element");
            firstNameInputElement.Id.Should().Be("firstName", "it should find the first name text box");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }


    }
}
