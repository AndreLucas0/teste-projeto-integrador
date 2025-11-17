using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace api.DTOs.NaturalPerson;

public class CreateNaturalPersonDTO
{
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateOnly Birth { get; set; }
}