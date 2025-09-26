using System.Threading;
using System.Threading.Tasks;
using Soenneker.Quark.Validations.Dtos;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark;

/// <summary>
/// Base class for all validation rules.
/// </summary>
public abstract class BaseValidationRule
{
    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected abstract string DefaultErrorMessage { get; }

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected abstract bool IsValidValue(object? value);

    /// <summary>
    /// Validates the value asynchronously using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected virtual Task<bool> IsValidValueAsync(object? value, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(IsValidValue(value));
    }

    /// <summary>
    /// Validates the value and sets the status and error message on the ValidatorEventArgs.
    /// </summary>
    /// <param name="args">The validator event arguments.</param>
    /// <param name="customMessage">Optional custom error message.</param>
    public virtual void Validate(ValidatorEventArgs args, string? customMessage = null)
    {
        if (IsValidValue(args.Value))
        {
            args.Status = ValidationStatus.Success;
            args.ErrorText = null;
        }
        else
        {
            args.Status = ValidationStatus.Error;
            args.ErrorText = customMessage ?? DefaultErrorMessage;
        }
    }

    /// <summary>
    /// Validates the value asynchronously and sets the status and error message on the ValidatorEventArgs.
    /// </summary>
    /// <param name="args">The validator event arguments.</param>
    /// <param name="customMessage">Optional custom error message.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public virtual async Task ValidateAsync(ValidatorEventArgs args, string? customMessage = null, CancellationToken cancellationToken = default)
    {
        if (await IsValidValueAsync(args.Value, cancellationToken))
        {
            args.Status = ValidationStatus.Success;
            args.ErrorText = null;
        }
        else
        {
            args.Status = ValidationStatus.Error;
            args.ErrorText = customMessage ?? DefaultErrorMessage;
        }
    }

    /// <summary>
    /// Validates the value and returns true if valid, false otherwise.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="customMessage">Optional custom error message (unused in this method).</param>
    /// <returns>True if valid, false otherwise.</returns>
    public virtual bool IsValid(object? value, string? customMessage = null)
    {
        return IsValidValue(value);
    }

    /// <summary>
    /// Validates the value asynchronously and returns true if valid, false otherwise.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="customMessage">Optional custom error message (unused in this method).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if valid, false otherwise.</returns>
    public virtual async Task<bool> IsValidAsync(object? value, string? customMessage = null, CancellationToken cancellationToken = default)
    {
        return await IsValidValueAsync(value, cancellationToken);
    }

    /// <summary>
    /// Gets the error message for this rule.
    /// </summary>
    /// <param name="customMessage">Optional custom error message.</param>
    /// <returns>The error message to display.</returns>
    public virtual string GetErrorMessage(string? customMessage = null)
    {
        return customMessage ?? DefaultErrorMessage;
    }
}
