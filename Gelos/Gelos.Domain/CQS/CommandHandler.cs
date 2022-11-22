using Gelos.Domain.Result;

namespace Gelos.Domain.CQS;

public abstract class CommandHandler<TCommand>: 
    HandlerBase<TCommand, Result.Result>, ICommandHandler<TCommand>
    where TCommand : Command
{
    protected CommandHandler()
    {
        InnerHandler = Handle;
    }
        
    public abstract Task<Result.Result> Handle(TCommand request, CancellationToken cancellationToken);
        
    protected Result.Result Successfully() => 
        Result.Result.Successfully();
    
    protected Result.Result Error(IError error) => 
        Result.Result.Error(error);
        
    protected Result<TResult> Successfully<TResult>(TResult result) => 
        Result<TResult>.Successfull(result);
}