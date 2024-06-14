using blog.Services.Blogs;
using FakeItEasy;

namespace Blog.Tests.Controllers.v1
{
    public class BlogControllerTests
    {
        private readonly IBlogService _blogService;

        public BlogControllerTests()
        {
            _blogService = A.Fake<IBlogService>();
         }

        [Fact]
        public async void BlogController_GetBlogs_ReturnsOK()
        {
        // Arrange
        var httpClient = new HttpClient();
        var endpointUrl = "http://localhost:5212/api/blog";
        
        // Act
        var response = await httpClient.GetAsync(endpointUrl);
        
        // Assert
        response.EnsureSuccessStatusCode(); // Ensure a successful HTTP response
        var content = await response.Content.ReadAsStringAsync();
        Assert.Equal("ExpectedValue", content);
        }

}
}