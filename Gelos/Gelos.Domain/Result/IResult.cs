namespace Gelos.Domain.Result;

public interface IResult
{
    bool IsSuccessfully { get; }
    void AddError(string error);
    string[] GetErrors();
}