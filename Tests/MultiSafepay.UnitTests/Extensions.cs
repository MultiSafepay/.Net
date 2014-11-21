using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MultiSafepay.UnitTests
{
    public static class StringExtensions
    {
        public static string RemoveWhiteSpace(this string input)
        {
            return Regex.Replace(input, @"[\s\r\n]+", "");
        }
    }
}
