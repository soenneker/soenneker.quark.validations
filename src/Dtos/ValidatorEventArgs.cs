using System;
using System.Collections.Generic;

namespace Soenneker.Quark.Validations.Dtos;

public sealed class ValidatorEventArgs
{
    public object? Value { get; init; }
    public Action? Failed { get; init; }
    public Action? Succeeded { get; init; }
    public Action<IEnumerable<string>>? Messages { get; init; }
}
