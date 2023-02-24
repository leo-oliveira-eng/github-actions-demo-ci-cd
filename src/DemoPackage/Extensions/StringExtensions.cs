namespace DemoPackage.Extensions;

/// <summary>
/// This class gathers the extension methods for strings
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// This method removes any non-numeric character from the string
    /// </summary>
    /// <param name="text">text from which non-numeric characters should be removed</param>
    /// <returns>numeric string</returns>
    public static string Clear(this string text)
        => string.IsNullOrWhiteSpace(text)
            ? string.Empty
            : new string(text.Where(char.IsDigit).ToArray());
}