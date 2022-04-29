using Gelos.DataAccess.Json.Entityes;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;


namespace Gelos.DataAccess.Json.Repository
{
    public class CalculationIssuesRepository : ICalculationIssuesRepository<Issue>
    {
        private readonly JsonContext<Issue> _context;

        public CalculationIssuesRepository(JsonContext<Issue> context)
        {
            _context = context;
        }

        public void Add(Issue issue)
        {
            // Легко могут быть повторяющиеся Id
            var issueId = GetAll().Count + 1;
            _context.Serialize(issue with { Id = issueId });
        }

        public void Delete(int id)
        {

        }

        public Issue Get(int id)
        {
            return null;
        }

        public List<IssueDto> GetAll()
        {
            return _context.Deserialize<IssueDto>();
        }

        public void Update(Issue issue)
        {

        }

    }
}