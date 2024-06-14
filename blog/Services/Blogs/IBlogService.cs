using Models.Entities;

namespace blog.Services.Blogs;

    public interface IBlogService
    {
        Task<Blog> CreateBlog(Blog blog);
        Task<Blog> UpdateBlog(Blog blog);
        Task<Blog> GetBlogById(Guid blogId);
        Task<Blog> GetBlogByTitle(string blogTitle);

        Task<IEnumerable<Blog>> GetBlogs();
        void DeleteBlog(Guid blogId);
    }
