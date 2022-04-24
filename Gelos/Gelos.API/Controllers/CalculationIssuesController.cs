
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gelos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gelos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationIssuesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(CreateCalculationIssueRequest request)
        {
            var (issue, error) = Issue.Create(request.Name, request.Description);

            if (!string.IsNullOrEmpty(error) || issue == null)
            {
                return BadRequest(new ProblemDetails() { Detail = error });
            }

            var repository = new List<Issue>();
            var issueId = repository.Count + 1;
            repository.Add(issue with { Id = issueId });

            return Ok(issue);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }
    }
}
