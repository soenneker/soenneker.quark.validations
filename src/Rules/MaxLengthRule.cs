
namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking maximum length.
/// </summary>
public class MaxLengthRule : BaseValidationRule
{
    private readonly int _maxLength;

    /// <summary>
    /// Initializes a new instance of the MaxLengthRule class.
    /// </summary>
    /// <param name="maxLength">The maximum allowed length.</param>
    public MaxLengthRule(int maxLength)
    {
        _maxLength = maxLength;
    }

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => $"The field must be no more than {_maxLength} characters long.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for length rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for length rule
        
        return stringValue.Length <= _maxLength;
    }
}
