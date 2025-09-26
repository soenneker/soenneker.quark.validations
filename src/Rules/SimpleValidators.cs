namespace Soenneker.Quark;

/// <summary>
/// Simple validators that can be used directly in markup.
/// </summary>
public static class SimpleValidators
{
    /// <summary>
    /// NotEmpty validator.
    /// </summary>
    public static readonly IValidator NotEmpty = new ValidationRuleAdapter(new NotEmptyRule());

    /// <summary>
    /// IsEmail validator.
    /// </summary>
    public static readonly IValidator IsEmail = new ValidationRuleAdapter(new IsEmailRule());

    /// <summary>
    /// IsUrl validator.
    /// </summary>
    public static readonly IValidator IsUrl = new ValidationRuleAdapter(new IsUrlRule());

    /// <summary>
    /// IsNumeric validator.
    /// </summary>
    public static readonly IValidator IsNumeric = new ValidationRuleAdapter(new IsNumericRule());

    /// <summary>
    /// IsInteger validator.
    /// </summary>
    public static readonly IValidator IsInteger = new ValidationRuleAdapter(new IsIntegerRule());

    /// <summary>
    /// Alphanumeric validator.
    /// </summary>
    public static readonly IValidator Alphanumeric = new ValidationRuleAdapter(new AlphanumericRule());

    /// <summary>
    /// DigitsOnly validator.
    /// </summary>
    public static readonly IValidator DigitsOnly = new ValidationRuleAdapter(new DigitsOnlyRule());

    /// <summary>
    /// Creates a MinLength validator.
    /// </summary>
    public static IValidator MinLength(int minLength, string? message = null) => 
        new ValidationRuleAdapter(new MinLengthRule(minLength), message);

    /// <summary>
    /// Creates a MaxLength validator.
    /// </summary>
    public static IValidator MaxLength(int maxLength, string? message = null) => 
        new ValidationRuleAdapter(new MaxLengthRule(maxLength), message);

    /// <summary>
    /// Creates a MinValue validator.
    /// </summary>
    public static IValidator MinValue(decimal minValue, string? message = null) => 
        new ValidationRuleAdapter(new MinValueRule(minValue), message);

    /// <summary>
    /// Creates a MaxValue validator.
    /// </summary>
    public static IValidator MaxValue(decimal maxValue, string? message = null) => 
        new ValidationRuleAdapter(new MaxValueRule(maxValue), message);
}
