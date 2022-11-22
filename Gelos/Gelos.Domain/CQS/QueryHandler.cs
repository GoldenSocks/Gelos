using Gelos.Domain.Result;

namespace Gelos.Domain.CQS;

public abstract class QueryHandler<TQuery, TResult>: 
    HandlerBase<TQuery, Result<TResult>>, IQueryHandler<TQuery, Result<TResult>>
    where TQuery : Query<TResult> 
{
    protected QueryHandler()
    {
        InnerHandler = Handle;
    }
        
    public abstract Task<Result<TResult>> Handle(TQuery request, CancellationToken cancellationToken);
        
    protected Result<TResult> Successfully(TResult result) => 
        Result<TResult>.Successfull(result);
    
    
    protected Result<TResult> Error(IError error) =>
        Result<TResult>.Error(error);
}