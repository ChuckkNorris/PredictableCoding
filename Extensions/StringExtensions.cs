using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
