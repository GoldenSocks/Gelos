using Gelos.Domain.CQS;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using Gelos.Domain.Result;

namespace Gelos.BusinessLogic.Features.Employee;

public class CreateIssueCommandHandler : CommandHandler<CreateIssueCommand>
{
    private readonly ICalculationIssuesRepository _calculationIssuesRepository;

    public CreateIssueCommandHandler(ICalculationIssuesRepository calculationIssuesRepository)
    {
        _calculationIssuesRepository = calculationIssuesRepository;
    }

    public override async Task<Result> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
    {
        var issue = Issue.Create(request.Name, request.Description, request.CreateDate);
        if (issue.IsFailure)
        {
            return Error(issue.Error);
        }
        await _calculationIssuesRepository.AddAsync(issue.Value);
        return Successfully();
    }
}