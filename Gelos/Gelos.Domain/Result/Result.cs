namespace Gelos.Domain.Result;

public class Result : IResult
{
    private readonly List<string> _errors = new();

    protected Result()
    {
    }

    public bool IsSuccessfully => _errors.Count < 1;

    public void AddError(string error)
    {
        if (error == null)
        {
            throw new ArgumentNullException($"{nameof(error)} must be not null");
        }
        _errors.Add(error);
    }

    public string[] GetErrors() => _errors.ToArray();

    public static Result Successfully() => new();
    
    public static Result Error(string error)
    {
        var result = new Result();
        result.AddError(error);
        return result;
    }
}