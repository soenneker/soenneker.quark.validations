using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark.Validations.Abstract;

public interface IValidation
{
    ValidationStatus Status { get; }
    System.Text.RegularExpressions.Regex? Pattern { get; }
    Microsoft.AspNetCore.Components.Forms.FieldIdentifier FieldIdentifier { get; }
    System.Collections.Generic.IEnumerable<string>? Messages { get; }

    System.Threading.Tasks.Task InitializeInput(IValidationInput input);
    System.Threading.Tasks.Task InitializeInputPattern<T>(string pattern, T value);
    System.Threading.Tasks.Task InitializeInputExpression<T>(System.Linq.Expressions.Expression<System.Func<T>> expression);
    System.Threading.Tasks.Task NotifyInputChanged<T>(T newValue, bool overrideNewValue = false);
    ValidationStatus Validate();
    ValidationStatus Validate(object newValidationValue);
    System.Threading.Tasks.Task<ValidationStatus> ValidateAsync();
    System.Threading.Tasks.Task<ValidationStatus> ValidateAsync(object newValidationValue);
    void Clear();
    void NotifyValidationStarted();
    void NotifyValidationStatusChanged(ValidationStatus status, System.Collections.Generic.IEnumerable<string>? messages = null);

    Microsoft.AspNetCore.Components.EventCallback<ValidationStatus> StatusChanged { get; }
}