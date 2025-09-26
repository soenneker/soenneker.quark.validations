using Soenneker.Quark.Validations.Rules.Base;
using System.Text.RegularExpressions;

namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking alphanumeric characters.
/// </summary>
public class AlphanumericRule : BaseValidationRule
{
    private static readonly Regex _alphanumericRegex = new(@"^[a-zA-Z0-9]+$");

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => "Please enter only letters and numbers.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for alphanumeric rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for alphanumeric rule
        
        return _alphanumericRegex.IsMatch(stringValue);
    }
}
