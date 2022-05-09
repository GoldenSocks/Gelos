﻿using Gelos.DataAccess.Json.Entities;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;


namespace Gelos.DataAccess.Json.Repository
{
    public class CalculationIssuesRepository : ICalculationIssuesRepository
    {
        private readonly JsonContext _context;

        public CalculationIssuesRepository(JsonContext context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            var issueId = SetId();

            var issueDto = new IssueDto
            {
                Id = issueId,
                Name = issue.Name,
                Description = issue.Description,
                CreateDate = issue.CreateDate,
                EndDate = issue.EndDate,
                Executor = new EmployeeDto { Id = issue.Executor?.Id ?? -1, Name = issue.Executor?.Name },
                Provider = new EmployeeDto { Id = issue.Executor?.Id ?? -1, Name = issue.Provider?.Name}
            };

            _context.Add(issueDto);
        }

        public void Delete(int id)
        {
            _context.Delete(id);
        }

        public Issue Get(int id)
        {
            return Get().FirstOrDefault(x => x.Id == id);
        }

        public List<Issue> Get()
        {
            var result = new List<Issue>();
            var issuesDto = _context.Get();

            foreach (var issueDto in issuesDto)
            {
                var (issue, error) = Issue.Create(issueDto.Name, issueDto.Description, issueDto.CreateDate, issueDto.Id);
                result.Add(issue);
            }
            return result;
        }

        public void Update(Issue issue)
        {

        }

        private int SetId()
        {
            var issues = Get();
            if (issues.Count != 0)
            {
                var ids = new List<int>();
                foreach (var issue in issues)
                {
                    ids.Add(issue.Id);
                }
                return ids.Max(x => x) + 1;
            }
            else 
                return 1;
        }
    }
}