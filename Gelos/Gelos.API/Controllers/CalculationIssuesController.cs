using Gelos.API.Contracts;
using Gelos.BusinessLogic.Features.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gelos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationIssuesController : BaseController
    {
        public CalculationIssuesController(IMediator mediator) : base(mediator) { }
        
        [HttpPost]
        public async Task<IActionResult> CreateIssue([FromBody] CreateCalculationIssueRequest request, CancellationToken ct)
        {
            var result = await _mediator.Send(new CreateIssueCommand
            {
                Name = request.Name,
                Description = request.Description
            }, ct);
            
            return result.IsSuccessfully ? 
                Ok() : BadRequest(result.GetErrors());
        }
    }
}
