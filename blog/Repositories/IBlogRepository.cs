using Models.Entities;

namespace blog.Repositories
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetBlogs();
        Task<Blog> GetBlog(Guid blodId);
        Task<Blog> GetBlogByTitle(string blogTitle);
        Task<Blog> CreateBlog(Blog blog);
        Task<Blog> UpdateBlog(Blog blog);
        Task DeleteBlog(Guid blodId);
    }
}