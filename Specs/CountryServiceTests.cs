//using Moq;
//using Moq.Protected;
//using System.Net;

//namespace Specs;


//public class CountryServiceTests
//{
//    [Fact]
//    public async Task GetAllCountriesAsync_ReturnsCountries()
//    {
//        // Arrange
//        var mockHandler = new Mock<HttpMessageHandler>();
//        mockHandler.Protected()
//            .Setup<Task<HttpResponseMessage>>(
//                "SendAsync",
//                ItExpr.IsAny<HttpRequestMessage>(),
//                ItExpr.IsAny<CancellationToken>()
//            )
//            .ReturnsAsync(new HttpResponseMessage
//            {
//                StatusCode = HttpStatusCode.OK,
//                Content = new StringContent("[{\"name\":{\"common\":\"Italy\"},\"capital\":[\"Rome\"]}]") // JSON fittizio
//            });

//        var httpClient = new HttpClient(mockHandler.Object);
//        var countryService = new CountriesImporter(httpClient);

//        // Act
//        var result = await countryService.GetAllCountriesAsync();

//        // Assert
//        Assert.NotNull(result);
//        Assert.Single(result);
//        Assert.Equal("Italy", result[0].Name.Common);
//    }
//}