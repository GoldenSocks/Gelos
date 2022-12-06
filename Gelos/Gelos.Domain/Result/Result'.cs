namespace Gelos.Domain.Result;

public class Result<TValue>: Result, IResult<TValue>
{
    public TValue Value { get; }

    private Result(TValue value)
    {
        Value = value;
    }

    private Result(string error)
    {
        AddError(error);
    }
        
    public static Result<TValue> Successfull<TValue>(TValue value)
    {
        return new Result<TValue>(value);
    }

    public new static Result<TValue> Error(string error)
    {
        return new Result<TValue>(error);
    }
}