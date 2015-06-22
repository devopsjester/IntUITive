namespace IntUITive.Selenium
{
    using System.Collections.Generic;
    using System.Linq;
    using OpenQA.Selenium;

    static class EnumerableExtensions
    {
        public static IEnumerable<IWebElement> WithShortestText(this IEnumerable<IWebElement> elements)
        {
            var elementsArray = elements as IWebElement[] ?? elements.ToArray();
            if (!elementsArray.Any())
            {
                return elementsArray;
            }
            var shortestElement = elementsArray.
                Aggregate(
                    (curMin, x) =>
                        (curMin == null || (x.Text == null ? int.MaxValue : x.Text.Length) < curMin.Text.Length
                            ? x
                            : curMin));

            return elementsArray.Where(e => e.Text.Length == shortestElement.Text.Length);
        } 
    }
}