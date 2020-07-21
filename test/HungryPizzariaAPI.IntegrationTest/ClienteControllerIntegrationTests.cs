using HungryPizzaAPI.CommonTest;
using HungryPizzaAPI.CommonTest.EntityBuilder;
using HungryPizzariaAPI;
using HungryPizzariaAPI.CommonTest;
using HungryPizzariaAPI.IntegrationTest;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace HungryClienteriaAPI.IntegrationTest
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class ClienteControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        const string URL = "/api/cliente";

        public ClienteControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task CreateCliente_Should_Return_Ok()
        {
            //Arrange
            var request = ClienteBuilder.CreateClienteRequest();
            var uri = $"{URL}/create";

            //Act
            var response = await _client.PostAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(2)]
        public async Task GetAllCliente_Should_Return_Ok()
        {
            // Arrange
            var uri = $"{URL}/getall";

            // Act
            var response = await _client.GetAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(3)]
        public async Task GetCliente_By_Id_Should_Return_Ok()
        {
            // Arrange
            var request = $"{URL}/getbyid/1";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(4)]
        public async Task UpdateCliente_Should_Return_Ok()
        {
            //Arrange
            var request = ClienteBuilder.UpdateClienteRequest();
            var uri = $"{URL}/update";

            //Act
            var response = await _client.PutAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(5)]
        public async Task DeleteCliente_Should_Return_Ok()
        {
            //Arrange
            var uri = $"{URL}/delete/1";

            //Act
            var response = await _client.DeleteAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}
