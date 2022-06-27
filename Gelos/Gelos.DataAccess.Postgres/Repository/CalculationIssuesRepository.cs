using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;


namespace Gelos.DataAccess.Postgres.Repository
{
    public class CalculationIssuesRepository : ICalculationIssuesRepository
    {
        private readonly GelosContext _context;

        public CalculationIssuesRepository(GelosContext context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            var issueDto = new IssueDto
            {
                Name = issue.Name,
                Description = issue.Description,
                CreateDate = issue.CreateDate,
                EndDate = issue.EndDate
            };

            _context.Add(issueDto);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var issue = _context.Issues.FirstOrDefault(x => x.Id == id);
            if(issue != null)
            {
                _context.Remove(issue);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public (Issue?, bool) Get(int id)
        {
            var issueDto = _context.Issues.FirstOrDefault(issue => issue.Id == id);
            
            if( issueDto != null)
            {
                var (issue, _) = Issue.Create(issueDto.Name, issueDto.Description, issueDto.CreateDate, issueDto.Id);
                return (issue, true);
            }
            return (null, false);
        }

        public List<Issue> Get()
        {
            var issuesDto = _context.Issues.ToList();

            var issues = new List<Issue>();

            foreach (var issueDto in issuesDto)
            {
                var (issue, _) = Issue.Create(issueDto.Name, issueDto.Description, issueDto.CreateDate, issueDto.Id);
                if(issue != null)
                {
                    issues.Add(issue);
                }
            }
            return issues;
        }

        public bool Update(int id)
        {
            var (issue, IsSuccess) = Get(id);

            if (IsSuccess)
            {
                var issueDto = new IssueDto
                {
                    Name = issue.Name,
                    Description = issue.Description,
                    CreateDate = issue.CreateDate,
                    EndDate = issue.EndDate
                };

                _context.Update(issueDto);
                _context.SaveChanges();
            }

            return IsSuccess;
        }
    }
}
