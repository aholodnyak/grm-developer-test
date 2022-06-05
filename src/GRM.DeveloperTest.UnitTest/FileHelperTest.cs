using System.IO;
using GRM.DeveloperTest.Core.Common;
using Xunit;

namespace GRM.DeveloperTest.UnitTest
{
    public class FileHelperTest
    {
        public static readonly object[][] FormatPathTestData =
        {
            new object[] { "text.txt", Path.GetFullPath("text.txt") },
            new object[] { "c:\\text.txt", "c:\\text.txt" },
            new object[] { "members\\text.txt", Path.GetFullPath("members\\text.txt") }
        };

        [Theory]
        [MemberData(nameof(FormatPathTestData))]
        public void FormatPath_all_path_formated(string value, string expected)
        {
            var actual = FileUtils.FormatPath(value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("data\\FileHelperTest\\ReadFileLines1.txt", 7)]
        [InlineData("data\\FileHelperTest\\ReadFileLines2.txt", 0)]
        [InlineData("data\\FileHelperTest\\ReadFileLines3.txt", 0)]
        [InlineData("data\\FileHelperTest\\NoFile.txt", 0)]
        public void ReadFileLines_correct_number_lines_read(string path, int rowCount)
        {
            var actual = FileUtils.ReadFileLines(path);
            Assert.Equal(rowCount, actual.Length);
        }
    }
}