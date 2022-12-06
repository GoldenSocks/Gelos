namespace Gelos.Domain.CQS;

public interface ICommandHandler<in TCommand> where TCommand: ICommand
{
    Task<Result.Result> Handle(TCommand request, CancellationToken cancellationToken);
}