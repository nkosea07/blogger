using blog.Models.DTOs;
using blog.Repositories;
using blog.Services.Blogs;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace blog.Controllers
{

    [ApiController]
    [Route("api/blog")]
    public class BlogController(IBlogService blogService) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetBlogPosts()
        {
          return StatusCode(StatusCodes.Status200OK, await blogService.GetBlogs());
        }

        [HttpGet("id:Guid")]
        public async Task<ActionResult<Blog>> GetBlogPost([FromQuery] Guid blogId)
        {

                var getBlogResult = await blogService.GetBlogById(blogId);
                if (getBlogResult != null)
                {
                    return StatusCode(StatusCodes.Status200OK,getBlogResult );
                }

                    return StatusCode(StatusCodes.Status404NotFound);
            
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlogPost([FromBody] BlogDto blogDto)
        {

                var blogEntity = new Blog()
                {
                    BlogTitle = blogDto.BlogTitle,
                    Description = blogDto.Description,
                    BlogAuthor=blogDto.BlogAuthor,
                    PostBody = blogDto.PostBody,
                    ImageUrl = blogDto.ImageUrl,
                    BlogPublisher = blogDto.BlogPublisher,
                };

                var blogPost = await blogService.GetBlogByTitle(blogDto.BlogTitle);
                if (blogPost != null)
                {
                    ModelState.AddModelError("Title", "A blog post with this title exists");
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
     
                var createBlogPostResult = await blogService.CreateBlog(blogEntity);
                return StatusCode(StatusCodes.Status201Created, createBlogPostResult);
            
        }


        [HttpPut]
        public async Task<ActionResult> UpdateBlogPost([FromQuery] Guid id, [FromBody] Blog blog)
        {

                var blogPost = await blogService.GetBlogById(id);
                if (blogPost != null)
                {
                    return StatusCode(StatusCodes.Status200OK,await blogService.UpdateBlog(blogPost)) ;
                }

                return StatusCode(StatusCodes.Status404NotFound,"Blog post with given ID does not exist");

            
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBlogPost([FromQuery] Guid id)
        {

                 var blogPostToDelete = await blogService.GetBlogById(id);
                 if (blogPostToDelete == null)
                 {
                     return StatusCode(StatusCodes.Status404NotFound,$"Blog post with id = {id} not found") ;
                 }
                  blogService.DeleteBlog(id);
                 return StatusCode(StatusCodes.Status204NoContent);
                
             }
        }
}