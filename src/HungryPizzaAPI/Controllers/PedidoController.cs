using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HungryPizzariaAPI.Application.Models.ItemPedido;
using HungryPizzariaAPI.Application.Models.Pedido;
using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HungryPizzariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAppService _service;

        public PedidoController(IPedidoAppService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var pedidos = await _service.GetAll();

            if (!pedidos.Any())
                return NotFound();

            return Ok(pedidos);
        }

        [HttpGet]
        [Route("GetByCodPedido/{codPedido}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByCodPedido(string codPedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());


            var result = await _service.GetByCodPedido(codPedido);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByClienteId/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByClienteId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = await _service.GetByClienteId(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var result = await _service.Delete(id);

                if (!result.Success)
                    return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }

        }


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] CreatePedidoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrorResponse());

                var response = await _service.Create(request);

                if (!response.Success)
                    return BadRequest(response.Erros);

                return Ok(new { CodPedido = response.CodPedido });
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }
        }        
    }
}
