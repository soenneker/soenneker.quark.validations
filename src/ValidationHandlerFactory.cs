using System;
using Soenneker.Quark.Validations.Abstract;
using Soenneker.Quark.Validations.Handlers;

namespace Soenneker.Quark.Validations;

internal static class ValidationHandlerFactory
{
    public static IValidationHandler Create(Type type)
    {
        if (type == ValidationHandlerType.Validator)
            return new ValidatorHandler();

        if (type == ValidationHandlerType.Pattern)
            return new PatternValidationHandler();

        if (type == ValidationHandlerType.DataAnnotation)
            return new DataAnnotationValidationHandler();

        throw new NotSupportedException();
    }
}