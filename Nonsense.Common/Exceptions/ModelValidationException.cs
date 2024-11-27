namespace Nonsense.Common.Exceptions;

public class ModelValidationException(string errorCode, Dictionary<string, string>? parameters = null)
    : BaseApiErrorException(errorCode, parameters);
