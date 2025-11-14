namespace api.Models;

public abstract class Client
{
    public long Id { get; private set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}