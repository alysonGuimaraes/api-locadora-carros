using CommonTestUtilities.Requests.User;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Test.User.Register
{
    public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly String _endpoint = "api/user";
        private readonly HttpClient _httpClient;
        public RegisterUserTest(CustomWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var response = await _httpClient.PostAsJsonAsync(_endpoint, request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            string? responseCreatedModel = responseData.RootElement.GetProperty("name").GetString();
            Assert.Equal(request.Name, responseCreatedModel);
        }

        // Add more unit tests
    }
}
