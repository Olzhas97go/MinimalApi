using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Interfaces;
using MinimalApi.Models;
using System.Net.Http.Json;

namespace MinimalApi.Tests
{
    public class ApplicationUserTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<IDatabaseService> _mockDbService = new();

        public ApplicationUserTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IDatabaseService>(_ => _mockDbService.Object);
                });
            });
        }

        [Fact]
        public async Task PostUser_ReturnsCreatedResult()
        {
            var newUser = new User { Username = "testuser", Email = "test@example.com" };
            _mockDbService.Setup(service => service.CreateNewUser(It.IsAny<User>())).ReturnsAsync(1);

            var client = _factory.CreateClient();
            var response = await client.PostAsJsonAsync("/users", newUser);

            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }
        
        [Fact]
        public async Task PostPost_ReturnsCreatedResult()
        {
            // Arrange
            var newPost = new Post { Title = "New Post", Body = "Post content", AuthorId = 1 };
            _mockDbService.Setup(service => service.CreateNewPost(It.IsAny<Post>())).ReturnsAsync(1);

            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/posts", newPost);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }
        
        [Fact]
        public async Task GetAllPosts_ReturnsOkResultWithPosts()
        {
            // Arrange
            var expectedPosts = new List<Post>
            {
                new Post { Title = "Post1", Body = "Content1", AuthorId = 1 },
                new Post { Title = "Post2", Body = "Content2", AuthorId = 2 }
            };
            _mockDbService.Setup(service => service.GetAllPosts()).ReturnsAsync(expectedPosts);

            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/posts");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            var posts = await response.Content.ReadFromJsonAsync<IEnumerable<Post>>();
            Assert.Equal(2, posts.Count());
        }
        
        [Fact]
        public async Task FollowUser_ReturnsOkResult()
        {
            // Arrange
            _mockDbService.Setup(service => service.FollowUser(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(true);

            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/follow", new { FollowerId = 1, FolloweeId = 2 });

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task LikePost_ReturnsOkResult()
        {
            // Arrange
            _mockDbService.Setup(service => service.LikePost(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(true);

            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/like", new { PostId = 1, UserId = 1 });

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}