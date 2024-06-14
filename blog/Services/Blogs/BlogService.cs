using System.Numerics;
using blog.Repositories;
using Models.Entities;

namespace blog.Services.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async  Task<IEnumerable<Blog>> GetBlogs()
        {
           return await _blogRepository.GetBlogs();
        }

        public async void DeleteBlog(Guid blogId)
        {
            await _blogRepository.DeleteBlog(blogId);
        }

        public async Task<Blog> GetBlogById(Guid blogId)
        {
            return await _blogRepository.GetBlog(blogId);
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            return await _blogRepository.UpdateBlog(blog);
        }

        public async Task<Blog> CreateBlog(Blog blog)
        {
            return await _blogRepository.CreateBlog(blog);
        }

        public async Task<Blog> GetBlogByTitle(string blogTitle)
        {
           return await _blogRepository.GetBlogByTitle(blogTitle);
        }
    }
}