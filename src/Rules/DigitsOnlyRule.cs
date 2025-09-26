using System.Text.RegularExpressions;

namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking digits only.
/// </summary>
public class DigitsOnlyRule : BaseValidationRule
{
    private static readonly Regex _digitsOnlyRegex = new(@"^\d+$");

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => "Please enter only digits.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for digits rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for digits rule
        
        return _digitsOnlyRegex.IsMatch(stringValue);
    }
}