using CSharpFunctionalExtensions;
using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Gelos.DataAccess.Postgres.Repository
{
    public class CalculationIssuesRepository : ICalculationIssuesRepository
    {
        private readonly GelosContext _context;

        public CalculationIssuesRepository(GelosContext context)
        {
            _context = context;
        }

        public async Task Add(Issue issue)
        {
            var issueDto = new IssueDto
            {
                Name = issue.Name,
                Description = issue.Description,
                CreateDate = issue.CreateDate,
                EndDate = issue.EndDate
            };

            _context.Add(issueDto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long issueId)
        {
            var issue = _context.Issues.FindAsync(issueId);
            if (issue.IsCompletedSuccessfully)
            {
                _context.Remove(issue);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Issue?> Get(long issueId)
        {
            var issueDto = await _context.Issues.FirstOrDefaultAsync(issue => issue.Id == issueId);
            
            if( issueDto != null)
            {
                var issue = Issue.Create(issueDto.Name, issueDto.Description, issueDto.CreateDate);
                return issue.Value;
            }
            return null;
        }

        public async Task<List<Issue>> Get()
        {
            var issuesDto = await _context.Issues.ToListAsync();

            var issues = new List<Issue>();

            foreach (var issueDto in issuesDto)
            {
                var issue = Issue.Create(issueDto.Name, issueDto.Description, issueDto.CreateDate);
                if(issue.IsSuccess)
                {
                    issues.Add(issue.Value);
                }
            }
            return issues;
        }

        public async Task<Result> Update(long issueId)
        {
            var issue = Get(issueId);

            if (issue.IsCompletedSuccessfully)
            {
                var issueDto = new IssueDto
                {
                    Name = issue.Result.Name,
                    Description = issue.Result.Description,
                    CreateDate = issue.Result.CreateDate,
                    EndDate = issue.Result.EndDate
                };

                _context.Update(issueDto);
                await _context.SaveChangesAsync();
            }
            return Result.Success();
        }
    }
}
