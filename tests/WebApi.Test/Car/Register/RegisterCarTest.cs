using CommonTestUtilities.Requests;
using RentCars.Exceptions;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using WebApi.Test.InlineData;

namespace WebApi.Test.Car.Register
{
    public class RegisterCarTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        public RegisterCarTest(CustomWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterCarJsonBuilder.Build();

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            string? responseCreatedModel = responseData.RootElement.GetProperty("model").GetString();
            Assert.Equal(request.Model, responseCreatedModel);
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Empty_Model(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.Model = String.Empty;

            if(_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");
            
            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("MODEL_EMPTY", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Empty_License_Plate(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.License_Plate = String.Empty;

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("LICENSE_PLATE_EMPTY", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Empty_Brand(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.Brand = String.Empty;

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("BRAND_EMPTY", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Empty_Year(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.Year = null;

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("YEAR_EMPTY", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Year_First_Ford(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.Year = 1906;

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("YEAR_FIRST_FORD", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Steering_Type_Invalid(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.Steering_type = "Test";

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("STEERING_TYPE_INVALID", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_License_Plate_Out_Of_Range(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.License_Plate = "ABC12345";

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("LICENSE_PLATE_LENGTH_OUT_OF_RANGE", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_License_Plate_Already_Registered(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.License_Plate = "ABC1234";

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("LICENSE_PLATE_ALREADY_REGISTERED", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Num_Passangers_Greater_Than_Zero(string culture)
        {
            var request = RequestRegisterCarJsonBuilder.Build();
            request.Num_passengers = 0;

            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);

            var response = await _httpClient.PostAsJsonAsync("api/Car", request);

            await using var responseBody = await response.Content.ReadAsStreamAsync();
            var responseData = await JsonDocument.ParseAsync(responseBody);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();
            Assert.Single(errors);

            var expectedMessage = ResourceExceptionMessages.ResourceManager.GetString("NUM_PASSENGER_NOT_GREATER_THAN_ZERO", new CultureInfo(culture));
            Assert.Contains(expectedMessage, errors.Select(e => e.GetString()));
        }
    }
}
