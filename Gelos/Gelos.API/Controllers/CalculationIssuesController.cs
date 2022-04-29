
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
