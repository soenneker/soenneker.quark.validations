using Soenneker.Quark.Validations.Rules.Base;
using System.Globalization;

namespace Soenneker.Quark.Validations.Rules;

/// <summary>
/// Validation rule for checking maximum value.
/// </summary>
public class MaxValueRule : BaseValidationRule
{
    private readonly decimal _maxValue;

    /// <summary>
    /// Initializes a new instance of the MaxValueRule class.
    /// </summary>
    /// <param name="maxValue">The maximum allowed value.</param>
    public MaxValueRule(decimal maxValue)
    {
        _maxValue = maxValue;
    }

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => $"The value must be no more than {_maxValue}.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for value rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for value rule
        
        if (decimal.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal decimalValue))
        {
            return decimalValue <= _maxValue;
        }
        
        return false;
    }
}
