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

    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    [DeploymentItem(@"TestPages\", "TestPages")]
    public class CodedUIBasedIntuitiveFindTest
    {
        public CodedUIBasedIntuitiveFindTest()
        {
        }

        [TestMethod]
        public void Find_WithNoTerm_ReturnsNull()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestPages", "PageWithTextBox.html");
            Assert.IsTrue(File.Exists(path));
            var browserWindow = BrowserWindow.Launch("file://"+path);
            var intuitively = Intuitively.Search(browserWindow);
            intuitively.Find(null).Should().BeNull("nothing comes from nothing.");

        }

        [TestMethod]
        public void Find_WithEmptyString_ReturnsNull()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestPages", "PageWithTextBox.html");
            Assert.IsTrue(File.Exists(path));
            var browserWindow = BrowserWindow.Launch("file://" + path);
            var intuitively = Intuitively.Search(browserWindow);
            intuitively.Find(string.Empty).Should().BeNull("empty term means empty hands.");
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
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
