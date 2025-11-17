using System.ComponentModel.DataAnnotations;

namespace api.Models;

public abstract class Client
{
    [Key]
    public long Id { get; private set; }
    public required List<Email> Emails { get; set; }
    public required List<Phone> Phones { get; set; }
    public required List<Address> Addresses { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}