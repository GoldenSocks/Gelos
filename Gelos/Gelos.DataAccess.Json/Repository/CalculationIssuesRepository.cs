using Gelos.DataAccess.Json.Entityes;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;


namespace Gelos.DataAccess.Json.Repository
{
    public class CalculationIssuesRepository : ICalculationIssuesRepository<Issue>
    {
        private readonly JsonContext _context;

        public CalculationIssuesRepository(JsonContext context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            var issueDto = new IssueDto
            {
                Id = issue.Id,
                Name = issue.Name,
                Description = issue.Description,
                CreateDate = issue.CreateDate,
                EndDate = issue.EndDate,
                Executor = new EmployeeDto { Id = issue.Executor?.Id, Name = issue.Executor?.Name},
                Provider = new EmployeeDto { Id = issue.Provider?.Id, Name = issue.Provider?.Name}
            };

            _context.Serialize(issueDto);
        }

        public void Delete(int id)
        {
            var issues = GetAll();

            if (issues.Count == 0) return;

            var itemToDelete = issues.Where(x => x.Id == id).Select(x => x).First();

            issues.Remove(itemToDelete);

            _context.DeleteJson();
            _context.UpdateJson();
            
            foreach (var issue in issues)
            {
                Add(issue);
            }
        }

        public Issue Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public List<Issue> GetAll()
        {
            var result = new List<Issue>();
            var issuesDto = _context.Deserialize();

            foreach (var item in issuesDto)
            {
                var (issue, error) = Issue.Create(item.Name, item.Description, item.CreateDate, item.Id);
                result.Add(issue);
            }
            return result;
        }

        public void Update(Issue issue)
        {

        }

    }
}