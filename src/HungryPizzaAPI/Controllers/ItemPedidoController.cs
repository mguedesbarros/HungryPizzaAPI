using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HungryPizzariaAPI.Application.Models.ItemPedido;
using HungryPizzariaAPI.Application.Models.Pedido;
using HungryPizzariaAPI.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizzariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoAppService _service;

        public ItemPedidoController(IItemPedidoAppService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = await _service.Delete(id);

            if (!result.Success)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Create([FromBody] CreateItemPedidoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = await _service.Create(request);

                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> Update([FromBody] UpdateItemPedidoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = await _service.Update(request);

                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetByPedidoId/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByPedidoId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = await _service.GetByPedidoId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }        
    }
}
