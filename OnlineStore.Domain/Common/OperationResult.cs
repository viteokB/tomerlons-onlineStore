namespace OnlineStore.Core.Common;

public record OperationResult(bool IsSuccess, string? Message = null)
{
    public static OperationResult Success(string? message = null)
    {
        return new OperationResult(true, message);
    }

    public static OperationResult Fail(string? message = null)
    {
        return new OperationResult( false, message);
    }
}

public record OperationResult<T>(T Data, bool IsSuccess, string? Message) 
    : OperationResult(IsSuccess, Message)
{
    public static OperationResult<T> Success(T data, string? message = null)
    {
        return new OperationResult<T>(data, true, message);
    }

    public new static OperationResult<T?> Fail(string? message = null)
    {
        return new OperationResult<T?>(default, false, message);
    }
}