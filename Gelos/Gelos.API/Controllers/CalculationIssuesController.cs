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
        public IActionResult Create(CreateCalculationIssueRequest request)
        {
            var response = _calculationIssuesService.Create(request.Name, request.Description);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _calculationIssuesService.Get();
            return Ok(response);
        }

        [HttpGet("{calculationIssueId:int}")]
        public IActionResult Get(int calculationIssueId)
        {
            var response = _calculationIssuesService.Get(calculationIssueId);
            return Ok(response);
        }

        [HttpDelete("{calculationIssueId:int}")]
        public IActionResult Delete(int calculationIssueId)
        {
            var response = _calculationIssuesService.Delete(calculationIssueId);
            return Ok(response);
        }

        [HttpPut("{calculationIssueId:int}")]
        public IActionResult Update(int calculationIssueId)
        {
            return Ok();
        }
    }
}
