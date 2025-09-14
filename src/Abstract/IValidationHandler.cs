using System.Threading;
using System.Threading.Tasks;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark.Validations;

public interface IValidationHandler
{
    void Validate(Validation ctx, object value);
    Task<ValidationStatus> ValidateAsync(Validation ctx, object value, CancellationToken cancellationToken);
}
