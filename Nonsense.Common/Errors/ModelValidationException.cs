namespace Nonsense.Common.Errors;

public class ModelValidationException(string errorCode, Dictionary<string, string>? parameters = null)
    : BaseApiErrorException(errorCode, parameters);
