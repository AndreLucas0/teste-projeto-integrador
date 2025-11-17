using api.DTOs.LegalEntity;
using api.Models;

namespace api.Interfaces.Services;

public interface ILegalEntityService
{
    Task<List<LegalEntity>> GetAll();
    Task<LegalEntity?> GetById(long id);
    Task<LegalEntity> Create(CreateLegalEntityDTO dto);
    Task<LegalEntity?> Update(long id, UpdateLegalEntityDTO dto);
    Task<bool> Delete(long id);
}