namespace Models.Entities
{
    public class Blog
    {
        
        public Guid BlogId { get; set;}
        public required string BlogTitle { get; set;}
        public required string Description { get; set;}
        public required string PostBody { get; set;}
        public DateTime Published { get; set;}
        public DateTime Updated { get; set;}
        public string? ImageUrl { get; set;}
        public required string BlogAuthor{ get; set;}
        public required string BlogPublisher{ get; set;}

    }
}