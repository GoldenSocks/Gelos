using Gelos.DataAccess.Postgres.Entities;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                EndDate = issue.EndDate,
                Executor = new EmployeeDto { Id = issue.Executor?.Id ?? -1, Name = issue.Executor?.Name },
                Provider = new EmployeeDto { Id = issue.Executor?.Id ?? -1, Name = issue.Provider?.Name }
            };

            _context.Add(issueDto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var issue = _context.Issues.FirstOrDefault(x => x.Id == id);
            if(issue != null)
            {
                _context.Remove(issue);
            }
        }

        public Issue Get(int id)
        {
            var issueDto = _context.Issues.FirstOrDefault(issue => issue.Id == id);
            if( issueDto != null)
            {
                var (issue, _) = Issue.Create(issueDto.Name, issueDto.Description, issueDto.CreateDate, issueDto.Id);
                if (issue != null) return issue;
            }
            return null;
        }

        public List<Issue> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(Issue issue)
        {
            throw new NotImplementedException();
        }
    }
}
