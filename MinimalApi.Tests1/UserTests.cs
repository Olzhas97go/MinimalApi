using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Xunit;
using MinimalApi.Models;
using MinimalApi.Interfaces;

namespace MinimalApi.Tests1;

public class UserTests
{
    [Fact]
    public async Task PostUser_ShouldReturnCreatedResult()
    {
        // Arrange
        var mockDbService = new Mock<IDatabaseService>();
        var testUser = new User { Username = "testuser", Email = "test@example.com" };
        mockDbService.Setup(service => service.CreateNewUser(It.IsAny<User>())).ReturnsAsync(1);

        var app = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped(_ => mockDbService.Object);
            });
        });

        var client = app.CreateClient();
        var jsonContent = JsonContent.Create(testUser);

        // Act
        var response = await client.PostAsync("/users", jsonContent);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        var returnedUser = await response.Content.ReadFromJsonAsync<User>();
        Assert.NotNull(returnedUser);
        Assert.Equal(testUser.Username, returnedUser.Username);
    }
}