using System;
using System.IO;
using System.Linq;

namespace GRM.DeveloperTest.Core.Common
{
    public static class FileUtils
    {
        public static string[] ReadFileLines(string path)
        {
            var filePath = FormatPath(path);
            return !File.Exists(filePath) ? Array.Empty<string>() : File.ReadAllLines(path).Skip(1).ToArray();
        }

        public static string FormatPath(string path)
        {
            return Path.IsPathRooted(path) ? path : Path.GetFullPath(path);
        }
    }
}