using FluentAssertions;
using HungryPizzaAPI.CommonTest;
using HungryPizzaAPI.CommonTest.EntityBuilder;
using HungryPizzariaAPI.Application.Models.Cliente;
using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HungryClienteriaAPI.UnitTests.Controllers
{
    public class ClienteControllerTest
    {
        private readonly Mock<IClienteAppService> _mock;
        private readonly ClienteController _controller;

        public ClienteControllerTest()
        {
            _mock = new Mock<IClienteAppService>();
            _controller = new ClienteController(_mock.Object);
        }

        [Fact]
        public void CreateCliente_Should_Return_Ok()
        {
            //Arrange
            var request = ClienteBuilder.CreateClienteRequest();
            var response = new CreateClienteResponse();

            //Act
            response.SetSucess(true);
            _mock.Setup(x => x.Create(request)).Returns(response);
            var result = _controller.Create(request) as OkResult;

            //Assert
            _mock.Verify(x => x.Create(It.IsAny<CreateClienteRequest>()), Times.Once);
            result.Should().NotBeNull("Return is null");
            result.Should().BeOfType<OkResult>("Return type is not valid.");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");

        }

        [Fact]
        public async Task GetAllCliente_Should_Return_Ok()
        {
            //Arrange
            var clientes = ClienteBuilder.GetClientesTest();

            //Act
            _mock.Setup(x => x.GetAll()).Returns(clientes);
            var result = await _controller.GetAll() as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<List<ClienteModel>>($"Return type is not List<ClienteModel>");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task GetCliente_By_Id_Should_Return_Ok()
        {
            //Arrange
            var cliente = await ClienteBuilder.GetClienteTest();

            //Act
            _mock.Setup(x => x.GetById(cliente.Id)).Returns(cliente);
            var result = _controller.GetById(cliente.Id) as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<ClienteModel>($"Return type is not ClienteModel");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task Delete_Should_Return_Ok()
        {
            //Arrange
            var cliente = await ClienteBuilder.GetClienteTest();
            var response = new DeleteClienteResponse();

            //Act
            response.SetSucess(true);
            _mock.Setup(x => x.Delete(cliente.Id)).Returns(response);
            var result = _controller.Delete(cliente.Id) as OkResult;

            //Assert
            result.Should().BeOfType<OkResult>("Tipo do resultado não é OkResult");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async void Update_Should_Return_Ok()
        {
            //Arrange
            var request = ClienteBuilder.UpdateClienteRequest();
            var response = new UpdateClienteResponse();

            //Act
            response.SetSucess(true);
            _mock.Setup(x => x.Update(request)).Returns(response);
            var result = _controller.Update(request) as OkResult;

            //Assert
            result.Should().NotBeNull("Retorno é null");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }
    }
}
