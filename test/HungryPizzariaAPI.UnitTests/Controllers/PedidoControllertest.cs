using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Controllers;
using Moq;
using HungryPizzariaAPI.CommonTest;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HungryPizzaAPI.CommonTest;
using HungryPizzariaAPI.Application.Models.Pedido;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentAssertions;
using HungryPizzaAPI.CommonTest.EntityBuilder;

namespace HungryPizzariaAPI.UnitTests.Controllers
{
    public class PedidoControllertest
    {
        private readonly Mock<IPedidoAppService> _mock;
        private readonly PedidoController _controller;

        public PedidoControllertest()
        {
            _mock = new Mock<IPedidoAppService>();
            _controller = new PedidoController(_mock.Object);
        }

        [Fact]
        public async Task CreatePedidoClienteCadastrado_Should_Return_Ok()
        {
            //Arrange
            var request = await PedidoBuilder.CreatePedidoClienteCadastradoRequest();
            var response = Task.Run(() => new CreatePedidoResponse());

            //Act
            response.Result.SetSucess(true);
            response.Result.CodPedido = "CP00000-01";
            _mock.Setup(x => x.Create(request)).Returns(response);
            var result = await _controller.Create(request) as OkObjectResult;

            //Assert
            _mock.Verify(x => x.Create(It.IsAny<CreatePedidoRequest>()), Times.Once);
            result.Should().NotBeNull("Return is null");
            result.Should().BeOfType<OkObjectResult>("Return type is not valid.");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");

        }

        [Fact]
        public async Task CreatePedidoClienteNovo_Should_Return_Ok()
        {
            //Arrange
            var request = await PedidoBuilder.CreatePedidoNovoClienteRequest();
            var response = Task.Run(() => new CreatePedidoResponse());

            //Act
            response.Result.SetSucess(true);
            response.Result.CodPedido = "CP00000-01";
            _mock.Setup(x => x.Create(request)).Returns(response);
            var result = await _controller.Create(request) as OkObjectResult;

            //Assert
            _mock.Verify(x => x.Create(It.IsAny<CreatePedidoRequest>()), Times.Once);
            result.Should().NotBeNull("Return is null");
            result.Should().BeOfType<OkObjectResult>("Return type is not valid.");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");

        }

        [Fact]
        public async Task GetAllPedido_Should_Return_Ok()
        {
            //Arrange
            var Pedidos = PedidoBuilder.GetPedidosTest();

            //Act
            _mock.Setup(x => x.GetAll()).Returns(Pedidos);
            var result = await _controller.GetAll() as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<List<PedidoModel>>($"Return type is not List<PedidoModel>");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task Delete_Should_Return_Ok()
        {
            //Arrange
            var response =Task.Run(() => new DeletePedidoResponse());

            //Act
            response.Result.SetSucess(true);
            _mock.Setup(x => x.Delete(1)).Returns(response);
            var result = await _controller.Delete(1) as OkResult;

            //Assert
            result.Should().BeOfType<OkResult>("Tipo do resultado não é OkResult");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task GetByCodPedido_Should_Return_Ok()
        {
            //Arrange
            var pedido = PedidoBuilder.GetPedidoTest();

            //Act
            _mock.Setup(x => x.GetByCodPedido("CP00000-01")).Returns(pedido);
            var result = await _controller.GetByCodPedido("CP00000-01") as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<PedidoModel>($"Return type is not List<PedidoModel>");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task GetPedidoByClienteId_Should_Return_Ok()
        {
            //Arrange
            var Pedidos = PedidoBuilder.GetPedidosTest();

            //Act
            _mock.Setup(x => x.GetByClienteId(1)).Returns(Pedidos);
            var result = await _controller.GetByClienteId(1) as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<List<PedidoModel>>($"Return type is not List<PedidoModel>");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }
    }
}
