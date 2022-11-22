namespace Gelos.Domain.Result;

public static class ResultExtensions
{
    public static T GetValue<T>(this IResult result)
    {
        if (result is not IResult<T> genericResult)
        {
            throw new NotSupportedException("Result not contains additional value");
        }

        return genericResult.Value;
    }
}