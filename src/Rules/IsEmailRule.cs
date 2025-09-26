using System.Text.RegularExpressions;

namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking email format.
/// </summary>
public class IsEmailRule : BaseValidationRule
{
    private static readonly Regex _emailRegex = new(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$", RegexOptions.IgnoreCase);

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => "Please enter a valid email address.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for email rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for email rule
        
        return _emailRegex.IsMatch(stringValue);
    }
}
