using HungryPizzaAPI.CommonTest;
using HungryPizzaAPI.CommonTest.EntityBuilder;
using HungryPizzariaAPI.CommonTest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace HungryPizzariaAPI.IntegrationTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class ItemPedidoControllerIntegrationTest : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        const string URL = "/api/itempedido";

        public ItemPedidoControllerIntegrationTest(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task CreateItemPedido_Should_Return_Ok()
        {
            //Arrange
            var request = await ItemPedidoBuilder.CreateItemPedidoRequest();
            var uri = $"{URL}/create";

            //Act
            var response = await _client.PostAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(2)]
        public async Task GetByPedidoId_Should_Return_Ok()
        {
            // Arrange
            var uri = $"{URL}/GetByPedidoId/1";

            // Act
            var response = await _client.GetAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(3)]
        public async Task DeletePedido_Should_Return_Ok()
        {
            //Arrange
            var uri = $"{URL}/delete/2";

            //Act
            var response = await _client.DeleteAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(4)]
        public async Task CreateItemPedido_Maior10_Should_Return_Invalid()
        {
            //Arrange
            var request = await ItemPedidoBuilder.CreateItemPedidoRequest();
            var uri = $"{URL}/create";

            //Act
            var response = await _client.PostAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
