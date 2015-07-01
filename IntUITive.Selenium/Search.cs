namespace IntUITive.Selenium
{
    using System;
    using System.Text.RegularExpressions;

    internal class Search
    {
        public Search(string term)
        {
            ParseTermString(term);
        }

        public int RequestedIndex { get; private set; }
        public string Term { get; private set; }

        private void ParseTermString(string term)
        {
            int foundIndex;
            const string indexPattern = @"^(?<term>[^\[]+)(?:\[(?<index>-?\d+)\])?$";
            var match = Regex.Match(term, indexPattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                throw new ArgumentException(string.Format("invalid search term: {0}", term), "term");
            }

            Term = match.Groups["term"].Value;
            RequestedIndex = int.TryParse(match.Groups["index"].Value, out foundIndex)
                ? foundIndex
                : 0;
        }
    }
}