using System.Collections.Generic;
using Soenneker.Quark.Validations.Abstract;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark.Validations.Dtos;

public sealed record ValidationsStatusChangedEventArgs(ValidationStatus Status, IReadOnlyCollection<string>? Messages, IValidation? Validation);
