using blog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Entities;

namespace blog.Controllers
{
    [Route("api/blog")]
    // [ApiVersion("1.0")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBlogPosts()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _blogRepository.GetBlogs());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        [HttpGet("id:Guid")]
        public async Task<ActionResult<Blog>> GetBlogPost([FromQuery] Guid blogId)
        {

            try
            {
                var getBlogResult = await _blogRepository.GetBlog(blogId);
                if (getBlogResult != null)
                {
                return StatusCode(StatusCodes.Status200OK,getBlogResult );
                }
                else
                {  
                return StatusCode(StatusCodes.Status404NotFound);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlogPost([FromBody] BlogDTO blogDTO)
        {
            // try
            // {
                var blogEntity = new Blog()
                {
                    FirstName = blogDTO.FirstName,
                    LastName = blogDTO.LastName,
                    BlogTitle = blogDTO.BlogTitle,
                    Description = blogDTO.Description,
                    BlogAuthor=blogDTO.BlogAuthor,
                    PostBody = blogDTO.PostBody,
                    ImageUrl = blogDTO.ImageUrl,
                    BlogPublisher = blogDTO.BlogPublisher,
                };

                var blogPost = await _blogRepository.GetBlogByTitle(blogDTO.BlogTitle);
                if (blogPost != null)
                {
                    ModelState.AddModelError("Title", "A blog post with this title exists");
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                else
                {
                    var createBlogPostResult = await _blogRepository.CreateBlog(blogEntity);
                    return StatusCode(StatusCodes.Status201Created, createBlogPostResult);
                }

            // }
            // catch (Exception)
            // {
            //     return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            // }
        }


        [HttpPut]
        public async Task<ActionResult> UpdateBlogPost([FromQuery] Guid id, [FromBody] Blog blog)
        {
            try
            {
                var blogPost = await _blogRepository.GetBlog(id);
                if (blogPost != null)
                {
                    return StatusCode(StatusCodes.Status200OK,await _blogRepository.UpdateBlog(blogPost)) ;
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound,"Blog post with given ID does not exist");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database"); 
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBlogPost([FromQuery] Guid id)
        {
             try
            {
                var blogPostToDelete = await _blogRepository.GetBlog(id);
                if (blogPostToDelete == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,$"Blog post with id = {id} not found") ;
                }
                    await _blogRepository.DeleteBlog(id);
                    return StatusCode(StatusCodes.Status204NoContent);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database"); 
            }
        }

    }

}