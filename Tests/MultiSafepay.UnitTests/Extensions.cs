using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MultiSafepay.UnitTests
{
    [ExcludeFromCodeCoverage]
    public static class StringExtensions
    {
        public static string RemoveWhiteSpace(this string input)
        {
            return Regex.Replace(input, @"[\s\r\n]+", "");
        }
    }
}
