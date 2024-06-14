namespace blog.Models.DTOs
{
    public class BlogDto
    {
        public required string BlogTitle { get; set;}
        public required string Description { get; set;}
        public required string PostBody { get; set;}
        public string? ImageUrl { get; set;}
        public required string BlogAuthor{ get; set;}
        public required string BlogPublisher{ get; set;}

    }
}