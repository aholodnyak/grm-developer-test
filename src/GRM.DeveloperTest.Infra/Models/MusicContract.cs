using System;
using System.Collections.Generic;
using GRM.DeveloperTest.Core.Common;

namespace GRM.DeveloperTest.Core.Models
{
    public class MusicContract
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public HashSet<string> Usages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public static MusicContract FromCsv(string csvLine)
        {
            var values = csvLine.Split('|');
            return new MusicContract
            {
                Artist = StringUtils.GetValueIfAny(values, 0),
                Title = StringUtils.GetValueIfAny(values, 1),
                Usages = StringUtils.ParseUsage(StringUtils.GetValueIfAny(values, 2)),
                StartDate = StringUtils.ParseDate(StringUtils.GetValueIfAny(values, 3)).GetValueOrDefault(),
                EndDate = StringUtils.ParseDate(StringUtils.GetValueIfAny(values, 4))
            };
        }

        public override string ToString()
        {
            return $"{Artist}|{Title}|{String.Join(", ", Usages)}|{FormatDate(StartDate)}|{FormatDate(EndDate)}";

            string FormatDate(DateTime? date)
            {
                return date.HasValue ? $"{StringUtils.GetDayWithSufix(date.Value.Day)} {date:MMM yyy}" : "";
            }
        }
    }
}