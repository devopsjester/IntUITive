namespace IntUITive.Selenium
{
    using System.Text.RegularExpressions;

    public static class MiscHelperExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static bool Resembles(this string input, string term)
        {
            return !input.IsNullOrEmpty() &&
                   Regex.IsMatch(input, term, RegexOptions.IgnoreCase);
        }
    }
}