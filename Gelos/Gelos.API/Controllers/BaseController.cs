using CSharpFunctionalExtensions;
using Gelos.API.Utils;
using Gelos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gelos.API.Controllers
{
    public class BaseController<TService, TModel> : Controller where TService : IService<TModel>
    {
        protected TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : Error(result.Error);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _service.Get(id);
            return Ok(response);
        }


        [HttpDelete("{id:long}")]
        public async Task Delete(long id)
        {
            await _service.Delete(id);
        }

        [HttpPut("{id:long}")]
        public async Task Update(long id)
        {
            await _service.Update(id);
        }
    }
}
