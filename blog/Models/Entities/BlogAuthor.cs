namespace Models.Entities;

public class BlogAuthor
{
    public Guid Id { get; set;}
    public required string FirstName { get; set;}
    public required string LastName { get; set;}
    public required string Email { get; set;}
    public string? ImageUrl { get; set;}

}