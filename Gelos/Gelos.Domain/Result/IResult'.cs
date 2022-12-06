namespace Gelos.Domain.Result;

public interface IResult<out T> : IResult
{
    T Value { get; }
}