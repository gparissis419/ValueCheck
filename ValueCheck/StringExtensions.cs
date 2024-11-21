namespace ValueCheck;

/// <summary>
/// String extension methods used for value checks
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Checks if the string has a value, meaning no null, empty, or spaces only
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>A validation check result.</returns>
    public static ValidationCheck<string> HasValue(this string? value)
        => !string.IsNullOrWhiteSpace(value)
            ? value
            : Error.WithMessage("A value is required");

    /// <summary>
    /// Checks if the string has a specific length
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="length">The required length.</param>
    /// <returns>A validation check result.</returns>
    public static ValidationCheck<string> HasLength(this string? value, int length)
        => value != null && value.Length == length
            ? value
            : Error.WithMessage($"Value should be {length} chars.");

    /// <summary>
    /// Checks if the string's length is below a maximum
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="max">The maximum length.</param>
    /// <returns>A validation check result.</returns>
    public static ValidationCheck<string> HasLengthBelow(this string? value, int max)
        => value != null
            ? value.Length <= max
                ? value
                : Error.WithMessage($"Value exceeds {max} chars.")
            : value;

    /// <summary>
    /// Checks if the string's length is above a minimum
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="min">The minimum length.</param>
    /// <returns>A validation check result.</returns>
    public static ValidationCheck<string> HasLengthAbove(this string? value, int min)
        => value != null && value.Length >= min
            ? value
            : Error.WithMessage($"Value must be minimum {min} chars.");

    /// <summary>
    /// Checks if the string's length is between two values
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="min">The minimum length.</param>
    /// <param name="max">The maximum length.</param>
    /// <returns>A validation check result.</returns>
    public static ValidationCheck<string> HasLengthInBetween(this string? value, int min, int max)
        => value != null && value.Length >= min && value.Length <= max
            ? value
            : Error.WithMessage($"Value must have minimum {min} chars and not exceed {max} chars.");

    /// <summary>
    /// Checks if the string matches a set of possible values
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="possibleValues">The set of possible values.</param>
    /// <returns>A validation check result.</returns>
    public static ValidationCheck<string> MustBe(this string? value, params string[] possibleValues)
        => value != null && possibleValues.Contains(value, StringComparer.InvariantCultureIgnoreCase)
            ? value
            : Error.WithMessage($"Value is not valid.");
}