using System.Collections.Generic;
using Soenneker.Quark.Validations.Enums;

namespace Soenneker.Quark.Validations.Dtos;

public sealed record ValidationStatusChangedEventArgs(ValidationStatus Status, IEnumerable<string>? Messages);
