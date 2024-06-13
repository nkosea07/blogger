namespace Models.Entities;

public class BlogPublisher
{
    public Guid Id { get; set;}
    public required string Name { get; set;}
    public required string Type { get; set;}
    public required string Email { get; set;}
    public string? LogoUrl { get; set;}

}