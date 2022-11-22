using MediatR;
using Gelos.Domain.Result;

namespace Gelos.Domain.CQS;

public class Query<TResult>: IQuery<Result<TResult>>, IRequest<Result<TResult>>
{
        
}