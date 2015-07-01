namespace IntUITive.Selenium.Tests.HtmlTestHelpers
{
    using System;
    using System.IO;

    public static class TestSample
    {
        public static string UriFromFile(string relativeFilePath)
        {
            var localPath = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(localPath, "TestSamples", relativeFilePath);
            return new Uri(filePath).AbsoluteUri;
        }
    }
}