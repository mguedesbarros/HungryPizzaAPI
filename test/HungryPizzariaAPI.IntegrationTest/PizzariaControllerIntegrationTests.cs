using HungryPizzariaAPI.CommonTest;
using HungryPizzariaAPI.CommonTest.EntityBuilder;
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
    public class PizzariaControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        const string URL = "/api/pizza";

        public PizzariaControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task CreatePizza_Should_Return_Ok()
        {
            //Arrange
            var request = PizzaBuilder.CreatePizzaRequest();
            var uri = $"{URL}/create";

            //Act
            var response = await _client.PostAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(2)]
        public async Task GetAllPizza_Should_Return_Ok()
        {
            // Arrange
            var uri = $"{URL}/getall";

            // Act
            var response = await _client.GetAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(3)]
        public async Task GetPizza_By_Id_Should_Return_Ok()
        {
            // Arrange
            var request = $"{URL}/getbyid/8";

            // Act
            var response = await _client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(4)]
        public async Task UpdatePizza_Should_Return_Ok()
        {
            //Arrange
            var request = PizzaBuilder.UpdatePizzaRequest();
            var uri = $"{URL}/update";

            //Act
            var response = await _client.PutAsync(uri, ContentHelper.GetStringContent(request));

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(5)]
        public async Task DeletePizza_Should_Return_Ok()
        {
            //Arrange
            var uri = $"{URL}/delete/8";

            //Act
            var response = await _client.DeleteAsync(uri);

            // Assert
            response.EnsureSuccessStatusCode();
        }

    }
}
