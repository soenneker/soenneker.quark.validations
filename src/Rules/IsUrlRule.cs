using Soenneker.Quark.Validations.Rules.Base;
using System;
using System.Text.RegularExpressions;

namespace Soenneker.Quark.Validations.Rules;

/// <summary>
/// Validation rule for checking URL format.
/// </summary>
public class IsUrlRule : BaseValidationRule
{
    private static readonly Regex _urlRegex = new(@"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$", RegexOptions.IgnoreCase);

    /// <summary>
    /// Gets the default error message for this validation rule.
    /// </summary>
    protected override string DefaultErrorMessage => "Please enter a valid URL.";

    /// <summary>
    /// Validates the value using the specific rule implementation.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <returns>True if valid, false otherwise.</returns>
    protected override bool IsValidValue(object? value)
    {
        if (value == null) return true; // Null values are valid for URL rule
        
        var stringValue = value.ToString();
        if (string.IsNullOrWhiteSpace(stringValue)) return true; // Empty values are valid for URL rule
        
        return Uri.TryCreate(stringValue, UriKind.Absolute, out Uri? uri) && 
               (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }
}
