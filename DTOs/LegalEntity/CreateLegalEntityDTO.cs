using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace api.DTOs.LegalEntity;

public class CreateLegalEntityDTO
{
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string BusinessName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
}