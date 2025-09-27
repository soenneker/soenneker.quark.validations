using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Extensions.String;

namespace Soenneker.Quark;

internal sealed class ValidatorHandler : IValidationHandler
{
    public void Validate(Validation ctx, object value)
    {
        var args = new ValidatorEventArgs(value);

        ctx.NotifyValidationStarted();
        
        if (ctx.Validator is IQuarkValidator validator)
        {
            validator.Validate(value);
            args.Status = validator.Status;
            args.ErrorText = validator.Status == ValidationStatus.Error ? validator.ErrorMessage : null;
        }
        else if (ctx.ValidationAction is not null)
        {
            ctx.ValidationAction.Invoke(args);
        }

        if (args.Status == ValidationStatus.Error)
        {
            var messages = new List<string>();

            if (args.ErrorText.HasContent())
                messages.Add(args.ErrorText);

            ctx.NotifyValidationStatusChanged(ValidationStatus.Error, messages);
        }
        else
        {
            ctx.NotifyValidationStatusChanged(args.Status);
        }
    }

    public async Task<ValidationStatus> ValidateAsync(Validation ctx, object value, CancellationToken cancellationToken)
    {
        var args = new ValidatorEventArgs(value);

        ctx.NotifyValidationStarted();

        if (ctx.AsyncValidationAction is not null)
        {
            await ctx.AsyncValidationAction.Invoke(args, cancellationToken);
        }
        else if (ctx.Validator is IQuarkValidator validator)
        {
            await validator.ValidateAsync(value, cancellationToken);
            args.Status = validator.Status;
            args.ErrorText = validator.Status == ValidationStatus.Error ? validator.ErrorMessage : null;
        }
        else if (ctx.ValidationAction is not null)
        {
            ctx.ValidationAction.Invoke(args);
        }

        if (args.Status == ValidationStatus.Error)
        {
            var messages = new List<string>();
            if (!string.IsNullOrEmpty(args.ErrorText))
                messages.Add(args.ErrorText);
            ctx.NotifyValidationStatusChanged(ValidationStatus.Error, messages);
        }
        else
        {
            ctx.NotifyValidationStatusChanged(args.Status);
        }

        return ctx.Status;
    }
}
