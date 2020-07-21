using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HungryPizzariaAPI.Application.Models.Cliente;
using HungryPizzariaAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizzariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _service;

        public ClienteController(IClienteAppService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = await _service.GetAll();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult GetById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = _service.Delete(id);

            if (!result.Success)
                return BadRequest();

            return Ok();
        }


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult Create([FromBody] CreateClienteRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = _service.Create(request);

                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public ActionResult Update([FromBody] UpdateClienteRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = _service.Update(request);

                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
