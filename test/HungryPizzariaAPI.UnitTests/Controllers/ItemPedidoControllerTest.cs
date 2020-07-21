using FluentAssertions;
using HungryPizzaAPI.CommonTest.EntityBuilder;
using HungryPizzariaAPI.Application.Models.ItemPedido;
using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizzariaAPI.UnitTests.Controllers
{
    public class ItemPedidoControllerTest
    {
        private readonly Mock<IItemPedidoAppService> _mock;
        private readonly ItemPedidoController _controller;

        public ItemPedidoControllerTest()
        {
            _mock = new Mock<IItemPedidoAppService>();
            _controller = new ItemPedidoController(_mock.Object);
        }

        [Fact]
        public async Task CreateItemPedido_Should_Return_Ok()
        {
            //Arrange
            var request = await ItemPedidoBuilder.CreateItemPedidoRequest();
            var response = Task.Run(() => new CreateItemPedidoResponse());

            //Act
            response.Result.SetSucess(true);
            _mock.Setup(x => x.Create(request)).Returns(response);
            var result = await _controller.Create(request) as OkResult;

            //Assert
            _mock.Verify(x => x.Create(It.IsAny<CreateItemPedidoRequest>()), Times.Once);
            result.Should().NotBeNull("Return is null");
            result.Should().BeOfType<OkResult>("Return type is not valid.");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task GetByPedidoId_Should_Return_Ok()
        {
            //Arrange
            var pedidos = ItemPedidoBuilder.GetItensPedidoTest();

            //Act
            _mock.Setup(x => x.GetByPedidoId(1)).Returns(pedidos);
            var result = await _controller.GetByPedidoId(1) as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<List<ItemPedidoModel>>($"Return type is not List<PedidoModel>");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task DeletePedido_Should_Return_Ok()
        {
            //Arrange
            var response = Task.Run(() => new DeleteItemPedidoResponse());

            //Act
            response.Result.SetSucess(true);
            _mock.Setup(x => x.Delete(1)).Returns(response);
            var result = await _controller.Delete(1) as OkResult;

            //Assert
            result.Should().BeOfType<OkResult>("Tipo do resultado não é OkResult");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }        
    }
}
