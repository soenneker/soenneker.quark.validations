using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Extensions.String;
using Soenneker.Quark.Validations.Abstract;
using Soenneker.Quark.Validations.Dtos;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark;

internal sealed class ValidatorHandler : IValidationHandler
{
    public void Validate(Validation ctx, object value)
    {
        var args = new ValidatorEventArgs(value);

        ctx.NotifyValidationStarted();
        ctx.Validator?.Invoke(args);

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

        if (ctx.AsyncValidator is not null)
            await ctx.AsyncValidator.Invoke(args, cancellationToken);
        else
            ctx.Validator?.Invoke(args);

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
