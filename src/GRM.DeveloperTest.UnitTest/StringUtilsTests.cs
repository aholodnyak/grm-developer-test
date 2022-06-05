using System;
using GRM.DeveloperTest.Core.Common;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class StringUtilsTests
    {
        public static readonly object[][] ParseDateTestData =
        {
            new object[] { "1st Feb 2012", new DateTime(2012, 2, 1) },
            new object[] { "2nd Feb 2012", new DateTime(2012, 2, 2) },
            new object[] { "3rd Feb 2012", new DateTime(2012, 2, 3) },
            new object[] { "10th Feb 2012", new DateTime(2012, 2, 10) },
            new object[] { "", null },
            new object[] { " ", null },
            new object[] { null, null }
        };


        public static readonly object[][] ParseUsageTestData =
        {
            new object[] { "digital download", new[] { "digital download" } },
            new object[] { "digital download, streaming", new[] { "digital download", "streaming" } },
            new object[] { "streaming", new[] { "streaming" } },
            new object[] { "digital download, streaming, ", new[] { "digital download", "streaming" } },
            new object[] { "digital download, streaming, , other", new[] { "digital download", "streaming", "other" } },
            new object[] { "", null },
            new object[] { " ", null },
            new object[] { null, null }
        };


        public static readonly object[][] ParseSearchStringTestData =
        {
            new object[] { "Partner Test 1st Feb 2012", "Partner Test", new DateTime(2012, 2, 1) },
            new object[] { "Partner 1st Feb 2012", "Partner", new DateTime(2012, 2, 1) },
            new object[] { "Partner 1st February 2012", "Partner", new DateTime(2012, 2, 1) },
            new object[] { "Partner 1st April 2012", "Partner", new DateTime(2012, 4, 1) },
            new object[] { "Partner log name 1st Apr 2012", "Partner log name", new DateTime(2012, 4, 1) }
        };

        [Theory]
        [InlineData("Tinie Tempah", 0)]
        [InlineData("Frisky (Live from SoHo)", 1)]
        [InlineData("digital download, streaming", 2)]
        [InlineData("1st Feb 2012", 3)]
        [InlineData(null, 4)]
        [InlineData(null, 5)]
        [InlineData(null, 6)]
        public void GetValueIfAny_check_if_all_values_can_be_get(string expectedValue, int index)
        {
            var testData = new[]
                { "Tinie Tempah", "Frisky (Live from SoHo)", "digital download, streaming", "1st Feb 2012", "", null };
            var actual = StringUtils.GetValueIfAny(testData, index);

            Assert.Equal(expectedValue, actual);
        }

        [Theory]
        [MemberData(nameof(ParseDateTestData))]
        public void ParseDate_parsing_correct_and_empty(string value, DateTime? expectedValue)
        {
            var actual = StringUtils.ParseDate(value);
            Assert.Equal(expectedValue, actual);
        }

        [Theory]
        [MemberData(nameof(ParseUsageTestData))]
        public void ParseUsage_parsing_correct_and_empty(string value, string[] expectedValue)
        {
            var actual = StringUtils.ParseUsage(value);
            if (expectedValue == null)
            {
                Assert.Null(actual);
                return;
            }

            for (var i = 0; i < expectedValue.Length; i++)
                Assert.Contains(expectedValue[i], actual);
        }

        [Theory]
        [MemberData(nameof(ParseSearchStringTestData))]
        public void ParseSearchString(string search, string expectedPartner, DateTime expectedDate)
        {
            var actual = StringUtils.ParseSearchString(search);
            Assert.Equal(expectedPartner, actual.partner);
            Assert.Equal(expectedDate, actual.date);
        }

        [Theory]
        [InlineData(1, "st")]
        [InlineData(2, "nd")]
        [InlineData(3, "rd")]
        [InlineData(4, "th")]
        [InlineData(5, "th")]
        [InlineData(6, "th")]
        [InlineData(7, "th")]
        [InlineData(8, "th")]
        [InlineData(9, "th")]
        [InlineData(11, "th")]
        [InlineData(12, "th")]
        [InlineData(13, "th")]
        [InlineData(14, "th")]
        [InlineData(15, "th")]
        [InlineData(16, "th")]
        [InlineData(17, "th")]
        [InlineData(18, "th")]
        [InlineData(19, "th")]
        [InlineData(20, "th")]
        [InlineData(21, "st")]
        [InlineData(22, "nd")]
        [InlineData(23, "rd")]
        [InlineData(24, "th")]
        [InlineData(25, "th")]
        [InlineData(26, "th")]
        [InlineData(27, "th")]
        [InlineData(28, "th")]
        [InlineData(29, "th")]
        [InlineData(30, "th")]
        [InlineData(31, "st")]
        public void CreateDateSuffix_tests(int day, string sufix)
        {
            var actual = StringUtils.GetDayWithSufix(day);
            Assert.Equal($"{day}{sufix}", actual);
        }
    }
}