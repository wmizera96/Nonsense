namespace Nonsense.Common.Errors;

public class ModelNotFoundException(string errorCode, Dictionary<string, string>? parameters = null)
    : BaseApiErrorException(errorCode, parameters);