using System.Runtime.CompilerServices;
using blog.Migrations;
using blog.Models;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace blog.Repositories
{
    public class BlogRepository : IBlogRepository
    {

        private readonly AppDbContext appDbContext;
        public BlogRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Blog> CreateBlog(Blog blog)
        {
            blog.Published = DateTime.UtcNow;
            blog.Updated = DateTime.UtcNow;
            var createBlogPostResult = await appDbContext.Blog.AddAsync(blog);
            await appDbContext.SaveChangesAsync();
            return createBlogPostResult.Entity;
        }

        public async Task DeleteBlog(Guid blodId)
        {
            var deleteResult = await appDbContext.Blog.FirstOrDefaultAsync(e => e.BlogId == blodId);
            if (deleteResult != null)
            {
                appDbContext.Blog.Remove(deleteResult);
                await appDbContext.SaveChangesAsync();

            }
            
        }

        public async Task<Blog> GetBlog(Guid BlodId)
        {
            var getBlogResult = await appDbContext.Blog
            .FirstOrDefaultAsync(b=> b.BlogId == BlodId);
            if(getBlogResult != null)
            {
                return getBlogResult;
            }
            else
            {
                return null;
            }
        }

        public async Task<Blog> GetBlogByTitle(string blogTitle)
        {
           var blogResult = await appDbContext.Blog
           .FirstOrDefaultAsync(b => b.BlogTitle == blogTitle);

           if(blogResult != null)
           { 
            return blogResult; 
           }

            return null;
        
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await appDbContext.Blog.ToListAsync();
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
           var blogResult = await appDbContext.Blog.FirstOrDefaultAsync(e => e.BlogId == blog.BlogId);
           if (blogResult != null)
           {
            blogResult.BlogTitle = blog.BlogTitle;
            blogResult.Description = blog.Description;
            blogResult.BlogAuthor = blog.BlogAuthor;
            blogResult.ImageUrl = blog.ImageUrl;
            blogResult.Updated = DateTime.UtcNow;

            await appDbContext.SaveChangesAsync();
            return blogResult;
           }
            return null;
        }
    }
}