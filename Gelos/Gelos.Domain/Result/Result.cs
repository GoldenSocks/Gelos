namespace Gelos.Domain.Result;

public class Result : IResult
{
    private readonly List<IError> _errors = new();

    protected Result()
    {
    }

    public bool IsSuccessfully => _errors.Count < 1;

    public void AddError(IError error)
    {
        if (error == null)
        {
            throw new ArgumentNullException($"{nameof(error)} must be not null");
        }
        _errors.Add(error);
    }

    public IError[] GetErrors() => _errors.ToArray();

    public static Result Successfully() => new();
    
    public static Result Error(IError error)
    {
        var result = new Result();
        result.AddError(error);
        return result;
    }
}