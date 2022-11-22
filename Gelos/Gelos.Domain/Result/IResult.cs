namespace Gelos.Domain.Result;

public interface IResult
{
    bool IsSuccessfully { get; }
    void AddError(IError error);
    IError[] GetErrors();
}