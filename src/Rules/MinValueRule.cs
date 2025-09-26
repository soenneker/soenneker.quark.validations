using System.Globalization;

namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking minimum value.
/// </summary>
public class MinValueRule : BaseValidationRule
{
    private readonly decimal _minValue;

    /// <summary>
    /// Initializes a new instance of the MinValueRule class.
    /// </summary>
    /// <param name="minValue">The minimum allowed value.</param>
    public MinValueRule(decimal minValue)
    {
        _minValue = minValue;
    }

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => $"The value must be at least {_minValue}.";

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
            return decimalValue >= _minValue;
        }
        
        return false;
    }
}
