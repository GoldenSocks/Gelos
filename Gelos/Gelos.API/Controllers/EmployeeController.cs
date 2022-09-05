using Gelos.API.Models;
using Gelos.Domain.Interfaces;
using Gelos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gelos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController<IEmployeeService, Employee>
    {

        public EmployeeController(IEmployeeService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeRequest request)
        {
            if(Enum.TryParse(request.Role, true, out Role result))
            {
                var response = await _service.Create(request.Name, result);
                return response.IsSuccess ? Ok() : Error(response.Error);
            }

            return Error("Invalid Role");
        }

    }
}
