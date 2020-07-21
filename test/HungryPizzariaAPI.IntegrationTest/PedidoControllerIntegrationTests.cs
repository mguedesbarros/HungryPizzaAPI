using FluentAssertions;
using HungryPizzaAPI.CommonTest.EntityBuilder;
using HungryPizzariaAPI.CommonTest;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace HungryPizzariaAPI.IntegrationTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class PedidoControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        const string URL = "/api/pedido";

        public PedidoControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task CreatePedido_Should_Return_Ok()
        {
            //Arrange
            var request = await PedidoBuilder.CreatePedidoClienteCadastradoRequest();
            var uri = $"{URL}/create";

            //Act
            var response = await _client.PostAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(2)]
        public async Task GetAllPedido_Should_Return_Ok()
        {
            // Arrange
            var uri = $"{URL}/getall";

            // Act
            var response = await _client.GetAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(4)]
        public async Task GetPedidoByCodPedido_Should_Return_Ok()
        {
            // Arrange
            var request = $"{URL}/GetByCodPedido/CP00001-01";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();


        }

        [Fact, Priority(5)]
        public async Task GetPedidoByClienteId_Should_Return_Ok()
        {
            // Arrange
            var request = $"{URL}/GetByClienteId/1";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

        }

        [Fact, Priority(6)]
        public async Task DeletePedido_Should_Return_Ok()
        {
            //Arrange
            var uri = $"{URL}/delete/2";

            //Act
            var response = await _client.DeleteAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(7)]
        public async Task CreatePedido_Item_Maior_10_Should_Return_BadRequest()
        {
            //Arrange
            var request = await PedidoBuilder.CreatePedidoItemMaior10Request();
            var uri = $"{URL}/create";

            //Act
            var response = await _client.PostAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
