using Gelos.API.Models;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Gelos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationIssuesController : BaseController<ICalculationIssuesService, Issue>
    {

        public CalculationIssuesController(ICalculationIssuesService calculationIssuesService) : base(calculationIssuesService)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCalculationIssueRequest request)
        {
            var response = await _service.Create(request.Name, request.Description);
            return response.IsSuccess ? Ok() : Error(response.Error);
        }

    }
}
