using Gelos.Domain.CQS;

namespace Gelos.BusinessLogic.Features.Employee;

public class CreateIssueCommand : Command
{
    public string Name { get; init; } = string.Empty;
    
    public string? Description { get; init; }
    
    public DateTime? CreateDate { get; init; }
}