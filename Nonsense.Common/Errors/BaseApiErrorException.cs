namespace Nonsense.Common.Errors;

public abstract class BaseApiErrorException(string errorCode, Dictionary<string, string>? parameters) : Exception
{
    public string ErrorCode { get; } = errorCode;
    public Dictionary<string, string>? Parameters { get; } = parameters;
}