namespace IntUITive.Selenium.Tests.HtmlTestHelpers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class TemporaryHelperFile : IDisposable
    {
        private readonly string _tempHtmlFile;

        public TemporaryHelperFile()
        {
            var tempFileName = Path.GetTempFileName();
            _tempHtmlFile = tempFileName + ".html";
            File.Move(tempFileName, _tempHtmlFile);
        }

        public string TempHtmlFile
        {
            get { return _tempHtmlFile; }
        }

        public void Dispose()
        {
            DeleteFile();
        }

        public string AsUri()
        {
            return new Uri(_tempHtmlFile).AbsoluteUri;
        }

        public void DeleteFile()
        {
            if (File.Exists(_tempHtmlFile))
            {
                File.Delete(_tempHtmlFile);
            }
        }

        public TemporaryHelperFile FromHtml(string htmlSource)
        {
            var hasDoctypeTag = Regex.IsMatch(htmlSource, @"\<!DOCTYPE", RegexOptions.IgnoreCase);
            var hasHtmlTag = Regex.IsMatch(htmlSource, @"\<html", RegexOptions.IgnoreCase);
            var hasHeadTag = Regex.IsMatch(htmlSource, @"\<head", RegexOptions.IgnoreCase);
            var hasBodyTag = Regex.IsMatch(htmlSource, @"\<body", RegexOptions.IgnoreCase);

            using (var sw = new StreamWriter(_tempHtmlFile))
            {
                var htmlBody = hasBodyTag ? htmlSource : string.Format("<body>{0}</body", htmlSource);
                var htmlContents = hasHeadTag
                    ? htmlBody
                    : string.Format("<head><meta charset=\"utf-8\" /><title>temporary test page</title></head>{0}",
                        htmlBody);
                var htmlElement = hasHtmlTag ? htmlContents : string.Format("<html>{0}</html>", htmlContents);
                var html = hasDoctypeTag ? htmlElement : string.Format("<!DOCTYPE html>{0}", htmlElement);

                sw.WriteLine(html);
                sw.Close();
            }

            return this;
        }
    }
}