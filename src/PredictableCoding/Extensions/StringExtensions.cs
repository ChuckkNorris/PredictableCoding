using System.Globalization;

namespace PredictableCoding.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string text)
        {
            string toReturn = null;
            var textInfo = new CultureInfo("en-US").TextInfo;
            toReturn = textInfo.ToTitleCase(text);
            return toReturn;
        }
    }
}
