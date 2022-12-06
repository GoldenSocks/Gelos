using CSharpFunctionalExtensions;
using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;

namespace Gelos.DataAccess.Postgres.Repository
{
    public class CalculationIssuesRepository : BaseRepository<Issue, IssueDto>, ICalculationIssuesRepository
    {
        public CalculationIssuesRepository(GelosContext context) : base(context) { }
        
        protected override IssueDto CreateEntityInstance(Issue issue)
        {
            var issueDto = new IssueDto
            {
                Id = issue.Id,
                Name = issue.Name,
                Description = issue.Description,
                CreateDate = issue.CreateDate,
                EndDate = issue.EndDate
            };
            return issueDto;
        }

        protected override Result<Issue> CreateModel(IssueDto entity)
        {
            return Issue.Create(entity.Name, entity.Description, entity.CreateDate, entity.Id);
        }
    }
}
