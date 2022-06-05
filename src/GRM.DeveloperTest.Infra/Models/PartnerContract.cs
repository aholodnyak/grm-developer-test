using System.Collections.Generic;
using GRM.DeveloperTest.Core.Common;

namespace GRM.DeveloperTest.Core.Models
{
    public class PartnerContract
    {
        public string Partner { get; set; }
        public HashSet<string> Usages { get; set; }

        public static PartnerContract FromCsv(string csvLine)
        {
            var values = csvLine.Split('|');
            return new PartnerContract
            {
                Partner = StringUtils.GetValueIfAny(values, 0),
                Usages = StringUtils.ParseUsage(StringUtils.GetValueIfAny(values, 1))
            };
        }
    }
}