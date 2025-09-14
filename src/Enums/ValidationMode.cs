using Intellenum;

namespace Soenneker.Quark.Validations.Enums;

/// <summary>
/// An enumeration for Quark, representing validation mode.
/// </summary>
[Intellenum<string>]
public sealed partial class ValidationMode
{
    public static readonly ValidationMode Auto = new("auto");
    public static readonly ValidationMode Manual = new("manual");
}
