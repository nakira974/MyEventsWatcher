using System.Text.RegularExpressions;

namespace MyEventsWatcher.Shared;

public static class StringExtensions
{
    private static readonly Regex CompiledUnicodeRegex = new Regex(@"[^\u0000-\u007F]", RegexOptions.Compiled);

    public static string StripUnicodeCharactersFromString(this string? inputValue)
    {
        return CompiledUnicodeRegex.Replace(inputValue ?? string.Empty, string.Empty);
    }
}