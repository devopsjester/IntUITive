namespace IntUITive.CodedUI
{
    using System;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

    public class Intuitively
    {
        private readonly BrowserWindow _browserWindow;

        private Intuitively(BrowserWindow browserWindow)
        {
            _browserWindow = browserWindow;
        }

        public static Intuitively Search(BrowserWindow browserWindow)
        {
            return new Intuitively(browserWindow);
        }

        public HtmlControl Find(string term)
        {
            if (term == null)
            {
                throw new ArgumentNullException("term");
            }
            if (term == string.Empty)
            {
                throw new ArgumentException("required parameter", "term");
            }

            var htmlControl = new HtmlControl(_browserWindow);
            htmlControl.SearchProperties[HtmlControl.PropertyNames.Id] = term;

            return htmlControl.Exists ? htmlControl : null;
        }
    }
}
