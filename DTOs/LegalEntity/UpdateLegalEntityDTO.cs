namespace api.DTOs.LegalEntity;

public class UpdateLegalEntityDTO
{
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string BusinessName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
}