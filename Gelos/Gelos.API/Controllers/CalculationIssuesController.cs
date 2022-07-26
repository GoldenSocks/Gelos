using Gelos.API.Models;
using Gelos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Gelos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationIssuesController : Controller
    {
        private readonly ICalculationIssuesService _calculationIssuesService;

        public CalculationIssuesController(ICalculationIssuesService calculationIssuesService)
        {
            _calculationIssuesService = calculationIssuesService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCalculationIssueRequest request)
        {
            var response = await _calculationIssuesService.Create(request.Name, request.Description);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _calculationIssuesService.Get();
            return Ok(response);
        }

        [HttpGet("{calculationIssueId:long}")]
        public async Task<IActionResult> Get(long calculationIssueId)
        {
            var response = await _calculationIssuesService.Get(calculationIssueId);
            return Ok(response);
        }

        [HttpDelete("{calculationIssueId:long}")]
        public async Task Delete(long calculationIssueId)
        {
            await _calculationIssuesService.Delete(calculationIssueId);
        }

        [HttpPut("{calculationIssueId:long}")]
        public async Task Update(long calculationIssueId)
        {
            await _calculationIssuesService.Update(calculationIssueId);
        }
    }
}
