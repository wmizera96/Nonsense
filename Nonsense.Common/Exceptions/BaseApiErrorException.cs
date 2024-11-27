namespace Nonsense.Common.Exceptions;

public abstract class BaseApiErrorException(string errorCode, Dictionary<string, string>? parameters) : Exception
{
    public string ErrorCode { get; } = errorCode;
    public Dictionary<string, string>? Parameters { get; } = parameters;
}