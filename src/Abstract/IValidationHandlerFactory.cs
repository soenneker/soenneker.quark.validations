using System;

namespace Soenneker.Quark.Validations;

public interface IValidationHandlerFactory
{
    IValidationHandler Create(Type type);
}
