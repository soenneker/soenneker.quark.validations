namespace Soenneker.Quark.Validations.Abstract;

public interface IValidationInput
{
    object? ValidationValue { get; }
    bool Disabled { get; }
}
