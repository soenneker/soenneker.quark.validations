using Soenneker.Quark.Validations.Rules.Base;

namespace Soenneker.Quark.Validations.Rules;

/// <summary>
/// Validation rule for checking if a value is not empty.
/// </summary>
public class NotEmptyRule : BaseValidationRule
{
    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => "This field is required.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        return !string.IsNullOrWhiteSpace(value?.ToString());
    }
}