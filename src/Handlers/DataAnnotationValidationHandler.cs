using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark.Validations.Handlers;

internal sealed class DataAnnotationValidationHandler : IValidationHandler
{
    public void Validate(Validation ctx, object value)
    {
        var messages = new List<string>();
        if (ctx.EditContext is not null)
        {
            var store = new ValidationMessageStore(ctx.EditContext);
            FieldIdentifier field = ctx.FieldIdentifier;
            store.Clear(field);

            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(field.Model);
            System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(
                field.Model?.GetType().GetProperty(field.FieldName)?.GetValue(field.Model),
                validationContext,
                results);

            foreach (ValidationResult r in results)
                messages.Add(r.ErrorMessage ?? "Invalid");

            if (messages.Any())
                ctx.NotifyValidationStatusChanged(ValidationStatus.Error, messages);
            else
                ctx.NotifyValidationStatusChanged(ValidationStatus.Success);

            ctx.EditContext.NotifyValidationStateChanged();
        }
        else
        {
            ctx.NotifyValidationStatusChanged(ValidationStatus.None);
        }
    }

    public Task<ValidationStatus> ValidateAsync(Validation ctx, object value, CancellationToken cancellationToken)
    {
        Validate(ctx, value);
        return Task.FromResult(ctx.Status);
    }
}
