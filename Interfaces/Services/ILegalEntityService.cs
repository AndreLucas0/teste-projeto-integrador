using api.DTOs.Client;
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
    Task<LegalEntity?> AddPhone(long id, CreatePhoneDTO dto);
    Task<LegalEntity?> AddEmail(long id, Email phone);
    Task<LegalEntity?> AddAddress(long id, Address phone);
    Task<LegalEntity?> RemovePhone(long id, long phoneId);
    Task<LegalEntity?> RemoveEmail(long id, long emailId);
    Task<LegalEntity?> RemoveAddress(long id, long phoneId);
}