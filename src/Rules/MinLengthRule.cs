
namespace Soenneker.Quark;

/// <summary>
/// Validation rule for checking minimum length.
/// </summary>
public class MinLengthRule : BaseValidationRule
{
    private readonly int _minLength;

    /// <summary>
    /// Initializes a new instance of the MinLengthRule class.
    /// </summary>
    /// <param name="minLength">The minimum required length.</param>
    public MinLengthRule(int minLength)
    {
        _minLength = minLength;
    }

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => $"The field must be at least {_minLength} characters long.";

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
        
        return stringValue.Length >= _minLength;
    }
}
