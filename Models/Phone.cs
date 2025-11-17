namespace api.Models;

public class Phone
{
    public long Id { get; private set; }
    public required string Number { get; set; }
    public long ClientId { get; set; }
    public required Client Client { get; set; }

}