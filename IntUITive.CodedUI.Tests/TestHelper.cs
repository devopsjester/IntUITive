namespace IntUITive.CodedUI.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UITesting;

    public class TestHelper
    {
        internal static BrowserWindow GetBrowserWindowFor(string htmlPageName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestPages", htmlPageName);
            var browserWindow = BrowserWindow.Launch("file://" + path);
            return browserWindow;
        }
    }
}