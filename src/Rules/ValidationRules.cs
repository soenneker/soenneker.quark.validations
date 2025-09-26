
namespace Soenneker.Quark;

/// <summary>
/// Main validation rules class that provides access to all validation rules.
/// </summary>
public static class ValidationRules
{
    // Static instances for rules that don't require parameters
    private static readonly NotEmptyRule _notEmptyRule = new();
    private static readonly IsNumericRule _isNumericRule = new();
    private static readonly IsIntegerRule _isIntegerRule = new();
    private static readonly IsEmailRule _isEmailRule = new();
    private static readonly IsUrlRule _isUrlRule = new();
    private static readonly AlphanumericRule _alphanumericRule = new();
    private static readonly DigitsOnlyRule _digitsOnlyRule = new();

    /// <summary>
    /// Gets the NotEmpty validation rule.
    /// </summary>
    public static class NotEmpty
    {
        /// <summary>
        /// Validates that the value is not empty.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _notEmptyRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value is not empty.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _notEmptyRule.IsValid(value, customMessage);
    }

    /// <summary>
    /// Gets the IsNumeric validation rule.
    /// </summary>
    public static class IsNumeric
    {
        /// <summary>
        /// Validates that the value is numeric.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _isNumericRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value is numeric.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _isNumericRule.IsValid(value, customMessage);
    }

    /// <summary>
    /// Gets the IsInteger validation rule.
    /// </summary>
    public static class IsInteger
    {
        /// <summary>
        /// Validates that the value is an integer.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _isIntegerRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value is an integer.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _isIntegerRule.IsValid(value, customMessage);
    }

    /// <summary>
    /// Gets the MinLength validation rule.
    /// </summary>
    public static class MinLength
    {
        /// <summary>
        /// Validates that the value meets the minimum length requirement.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="minLength">The minimum required length.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, int minLength, string? customMessage = null)
        {
            var rule = new MinLengthRule(minLength);
            rule.Validate(args, customMessage);
        }

        /// <summary>
        /// Validates that the value meets the minimum length requirement.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="minLength">The minimum required length.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, int minLength, string? customMessage = null)
        {
            var rule = new MinLengthRule(minLength);
            return rule.IsValid(value, customMessage);
        }
    }

    /// <summary>
    /// Gets the MaxLength validation rule.
    /// </summary>
    public static class MaxLength
    {
        /// <summary>
        /// Validates that the value meets the maximum length requirement.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="maxLength">The maximum allowed length.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, int maxLength, string? customMessage = null)
        {
            var rule = new MaxLengthRule(maxLength);
            rule.Validate(args, customMessage);
        }

        /// <summary>
        /// Validates that the value meets the maximum length requirement.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="maxLength">The maximum allowed length.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, int maxLength, string? customMessage = null)
        {
            var rule = new MaxLengthRule(maxLength);
            return rule.IsValid(value, customMessage);
        }
    }

    /// <summary>
    /// Gets the MinValue validation rule.
    /// </summary>
    public static class MinValue
    {
        /// <summary>
        /// Validates that the value meets the minimum value requirement.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="minValue">The minimum allowed value.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, decimal minValue, string? customMessage = null)
        {
            var rule = new MinValueRule(minValue);
            rule.Validate(args, customMessage);
        }

        /// <summary>
        /// Validates that the value meets the minimum value requirement.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="minValue">The minimum allowed value.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, decimal minValue, string? customMessage = null)
        {
            var rule = new MinValueRule(minValue);
            return rule.IsValid(value, customMessage);
        }
    }

    /// <summary>
    /// Gets the MaxValue validation rule.
    /// </summary>
    public static class MaxValue
    {
        /// <summary>
        /// Validates that the value meets the maximum value requirement.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="maxValue">The maximum allowed value.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, decimal maxValue, string? customMessage = null)
        {
            var rule = new MaxValueRule(maxValue);
            rule.Validate(args, customMessage);
        }

        /// <summary>
        /// Validates that the value meets the maximum value requirement.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="maxValue">The maximum allowed value.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, decimal maxValue, string? customMessage = null)
        {
            var rule = new MaxValueRule(maxValue);
            return rule.IsValid(value, customMessage);
        }
    }

    /// <summary>
    /// Gets the IsEmail validation rule.
    /// </summary>
    public static class IsEmail
    {
        /// <summary>
        /// Validates that the value is a valid email address.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _isEmailRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value is a valid email address.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _isEmailRule.IsValid(value, customMessage);
    }

    /// <summary>
    /// Gets the IsUrl validation rule.
    /// </summary>
    public static class IsUrl
    {
        /// <summary>
        /// Validates that the value is a valid URL.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _isUrlRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value is a valid URL.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _isUrlRule.IsValid(value, customMessage);
    }

    /// <summary>
    /// Gets the Alphanumeric validation rule.
    /// </summary>
    public static class Alphanumeric
    {
        /// <summary>
        /// Validates that the value contains only alphanumeric characters.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _alphanumericRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value contains only alphanumeric characters.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _alphanumericRule.IsValid(value, customMessage);
    }

    /// <summary>
    /// Gets the DigitsOnly validation rule.
    /// </summary>
    public static class DigitsOnly
    {
        /// <summary>
        /// Validates that the value contains only digits.
        /// </summary>
        /// <param name="args">The validator event arguments.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        public static void Validate(ValidatorEventArgs args, string? customMessage = null)
            => _digitsOnlyRule.Validate(args, customMessage);

        /// <summary>
        /// Validates that the value contains only digits.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="customMessage">Optional custom error message.</param>
        /// <returns>True if valid, false otherwise.</returns>
        public static bool IsValid(object? value, string? customMessage = null)
            => _digitsOnlyRule.IsValid(value, customMessage);
    }

    // Simple static validators that can be used directly in markup
    /// <summary>
    /// Simple validation rules that can be used directly in markup.
    /// </summary>
    public static class Rules
    {
        /// <summary>
        /// NotEmpty validation rule.
        /// </summary>
        public static readonly IValidator NotEmpty = new ValidationRuleAdapter(_notEmptyRule);

        /// <summary>
        /// IsEmail validation rule.
        /// </summary>
        public static readonly IValidator IsEmail = new ValidationRuleAdapter(_isEmailRule);

        /// <summary>
        /// IsUrl validation rule.
        /// </summary>
        public static readonly IValidator IsUrl = new ValidationRuleAdapter(_isUrlRule);

        /// <summary>
        /// IsNumeric validation rule.
        /// </summary>
        public static readonly IValidator IsNumeric = new ValidationRuleAdapter(_isNumericRule);

        /// <summary>
        /// IsInteger validation rule.
        /// </summary>
        public static readonly IValidator IsInteger = new ValidationRuleAdapter(_isIntegerRule);

        /// <summary>
        /// Alphanumeric validation rule.
        /// </summary>
        public static readonly IValidator Alphanumeric = new ValidationRuleAdapter(_alphanumericRule);

        /// <summary>
        /// DigitsOnly validation rule.
        /// </summary>
        public static readonly IValidator DigitsOnly = new ValidationRuleAdapter(_digitsOnlyRule);
    }
}
