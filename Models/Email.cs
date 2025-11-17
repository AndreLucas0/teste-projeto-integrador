namespace api.Models;

public class Email
{
    public long Id { get; private set; }
    public required string EmailAddress { get; set; }
    public long ClientId { get; set; }
    public required Client Client { get; set; }
}