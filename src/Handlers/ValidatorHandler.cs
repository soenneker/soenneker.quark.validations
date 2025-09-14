using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Quark.Validations.Dtos;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark.Validations.Handlers;

internal sealed class ValidatorHandler : IValidationHandler
{
    public void Validate(Validation ctx, object value)
    {
        var messages = new List<string>();
        var args = new ValidatorEventArgs
        {
            Value = value,
            Failed = () => { },
            Succeeded = () => { },
            Messages = m => messages = m.ToList(),
        };

        ctx.NotifyValidationStarted();
        ctx.Validator?.Invoke(args);

        if (messages.Any())
            ctx.NotifyValidationStatusChanged(ValidationStatus.Error, messages);
        else
            ctx.NotifyValidationStatusChanged(ValidationStatus.Success);
    }

    public async Task<ValidationStatus> ValidateAsync(Validation ctx, object value, CancellationToken cancellationToken)
    {
        var messages = new List<string>();
        var args = new ValidatorEventArgs
        {
            Value = value,
            Failed = () => { },
            Succeeded = () => { },
            Messages = m => messages = m.ToList(),
        };

        ctx.NotifyValidationStarted();
        if (ctx.AsyncValidator is not null)
            await ctx.AsyncValidator.Invoke(args, cancellationToken);
        else
            ctx.Validator?.Invoke(args);

        if (messages.Any())
            ctx.NotifyValidationStatusChanged(ValidationStatus.Error, messages);
        else
            ctx.NotifyValidationStatusChanged(ValidationStatus.Success);

        return ctx.Status;
    }
}
