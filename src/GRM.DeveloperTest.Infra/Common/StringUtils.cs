using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Chronic.Core;

namespace GRM.DeveloperTest.Core.Common
{
    public class StringUtils
    {
        public static string GetValueIfAny(string[] values, int index)
        {
            return values.Length > index && !string.IsNullOrWhiteSpace(values[index])
                ? values[index].Trim()
                : null;
        }

        public static DateTime? ParseDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            var parser = new Parser();
            return parser.Parse(value).Start;
        }

        public static HashSet<string> ParseUsage(string value)
        {
            return string.IsNullOrWhiteSpace(value)
                ? null
                : new HashSet<string>(value.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()));
        }


        public static (string partner, DateTime date) ParseSearchString(string searchString)
        {
            var pattern = @"([a-zA-Z0-9_ ]*\s)(\d{1,2}(?:st|nd|rd|th)\s\w{3,10}\s\d{4})";
            var matches = Regex.Match(searchString, pattern);
            var partnerText = matches.Groups[1].Value.Trim();
            var date = new Parser().Parse(matches.Groups[2].Value.Trim()).Start.GetValueOrDefault();
            return (partnerText, date);
        }

        public static string GetDayWithSufix(int day)
        {
            var dayM = day % 10;

            var suffix = day.ToString(CultureInfo.InvariantCulture);

            suffix += day == 11 || day == 12 || day == 13 ? "th" :
                dayM == 1 ? "st" :
                dayM == 2 ? "nd" :
                dayM == 3 ? "rd" :
                "th";

            return suffix;
        }

    }
}