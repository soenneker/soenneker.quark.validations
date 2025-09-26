using Soenneker.Quark.Validations.Rules.Base;
using System.Globalization;

namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking if a value is an integer.
/// </summary>
public class IsIntegerRule : BaseValidationRule
{
    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => "Please enter a valid integer.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for integer rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for integer rule
        
        return int.TryParse(stringValue, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
    }
}
