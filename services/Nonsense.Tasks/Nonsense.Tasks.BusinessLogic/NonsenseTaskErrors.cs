using Nonsense.Common.Exceptions;

namespace Nonsense.Tasks.BusinessLogic;

public static class NonsenseTaskErrors
{
    public static ModelNotFoundException NotFound() => new(ErrorCodes.NonsenseTaskNotFound);

    public static ModelValidationException NameAlreadyExists() => new(ErrorCodes.NonsenseTaskNameAlreadyExists);
}