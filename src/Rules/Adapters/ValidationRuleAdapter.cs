using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Quark;

/// <summary>
/// Adapter class that wraps a BaseValidationRule to implement IValidator interface.
/// This allows validation rules to be used directly as validators in markup.
/// </summary>
public class ValidationRuleAdapter : IValidator
{
    private readonly BaseValidationRule _rule;
    private readonly string? _customMessage;

    /// <summary>
    /// Initializes a new instance of the ValidationRuleAdapter class.
    /// </summary>
    /// <param name="rule">The validation rule to wrap.</param>
    /// <param name="customMessage">Optional custom error message.</param>
    public ValidationRuleAdapter(BaseValidationRule rule, string? customMessage = null)
    {
        _rule = rule ?? throw new ArgumentNullException(nameof(rule));
        _customMessage = customMessage;
    }

    /// <inheritdoc/>
    public string ErrorMessage => _rule.GetErrorMessage(_customMessage);

    /// <inheritdoc/>
    public ValidationStatus Status { get; private set; } = ValidationStatus.None;

    /// <inheritdoc/>
    public bool Validate(object value)
    {
        bool isValid = _rule.IsValid(value, _customMessage);
        Status = isValid ? ValidationStatus.Success : ValidationStatus.Error;
        return isValid;
    }

    /// <inheritdoc/>
    public async Task<bool> ValidateAsync(object value, CancellationToken cancellationToken = default)
    {
        bool isValid = await _rule.IsValidAsync(value, _customMessage, cancellationToken);
        Status = isValid ? ValidationStatus.Success : ValidationStatus.Error;
        return isValid;
    }
}
