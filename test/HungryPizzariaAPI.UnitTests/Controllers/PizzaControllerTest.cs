using FluentAssertions;
using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Controllers;
using HungryPizzariaAPI.CommonTest;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HungryPizzariaAPI.CommonTest.EntityBuilder;

namespace HungryPizzariaAPI.UnitTests.Controllers
{
    public class PizzaControllerTest
    {
        private readonly Mock<IPizzaAppService> _mock;
        private readonly PizzaController _controller;

        public PizzaControllerTest()
        {
            _mock = new Mock<IPizzaAppService>();
            _controller = new PizzaController(_mock.Object);
        }

        [Fact]
        public void CreatePizza_Should_Return_Ok()
        {
            //Arrange
            var request = PizzaBuilder.CreatePizzaRequest();
            var response = new CreatePizzaResponse();
            
            //Act
            response.SetSucess(true);
            _mock.Setup(x => x.Create(request)).Returns(response);
            var result = _controller.Create(request) as OkResult;

            //Assert
            _mock.Verify(x => x.Create(It.IsAny<CreatePizzaRequest>()), Times.Once);
            result.Should().NotBeNull("Return is null");
            result.Should().BeOfType<OkResult>("Return type is not valid.");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");

        }

        [Fact]
        public async Task GetAllPizza_Should_Return_Ok()
        {
            //Arrange
            var pizzas = PizzaBuilder.GetPizzasTest();

            //Act
            _mock.Setup(x => x.GetAll()).Returns(pizzas);
            var result = await _controller.GetAll() as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<List<PizzaModel>>($"Return type is not List<PizzaModel>");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task GetPizza_By_Id_Should_Return_Ok()
        {
            //Arrange
            var pizza = await PizzaBuilder.GetPizzaTest();

            //Act
            _mock.Setup(x => x.GetById(pizza.Id)).Returns(pizza);
            var result = _controller.GetById(pizza.Id) as OkObjectResult;

            //Assert
            result.Should().NotBeNull("Result is null.");
            result.Value.Should().BeOfType<PizzaModel>($"Return type is not PizzaModel");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async Task Delete_Should_Return_Ok()
        {
            //Arrange
            var pizza = await PizzaBuilder.GetPizzaTest();
            var response = new DeletePizzaResponse();

            //Act
            response.SetSucess(true);
            _mock.Setup(x => x.Delete(pizza.Id)).Returns(response);
            var result = _controller.Delete(pizza.Id) as OkResult;

            //Assert
            result.Should().BeOfType<OkResult>("Tipo do resultado não é OkResult");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        [Fact]
        public async void Update_Should_Return_Ok()
        {
            //Arrange
            var request = PizzaBuilder.UpdatePizzaRequest();
            var response = new UpdatePizzaResponse();

            //Act
            response.SetSucess(true);
            _mock.Setup(x => x.Update(request)).Returns(response);
            var result = _controller.Update(request) as OkResult;

            //Assert
            result.Should().NotBeNull("Retorno é null");
            result.StatusCode.Should().Be(200, $"Status Code {result.StatusCode}");
        }

        //[Fact]
        //public void Create_InvalidModelState_CreatePizzaNeverExecutes()
        //{
        //    //Arrange
        //    var request = PizzaBuilder.CreatePizzaRequestInvalidModelState();
        //    var response = new CreatePizzaResponse();

        //    //Act
        //    _controller.ModelState.AddModelError("Sabor", "O Sabor é obrigatorio");
        //    _mock.Setup(x => x.Create(request));
        //    _controller.Create(request);

        //    //Assert
        //    _mock.Verify(x => x.Create(It.IsAny<CreatePizzaRequest>()), Times.Never);
        //}
    }
}
