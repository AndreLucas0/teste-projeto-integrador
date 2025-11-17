using System.Threading.Tasks;
using api.Data;
using api.DTOs.LegalEntity;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Models;
using api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class LegalEntityService : ILegalEntityService
{
    
    private readonly ILegalEntityRepository _repository;

    public LegalEntityService (ILegalEntityRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<LegalEntity> Create(CreateLegalEntityDTO dto)
    {
        var legalEntity = new LegalEntity{
            Email = dto.Email,
            Phone = dto.Phone,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            BusinessName = dto.BusinessName,
            CompanyName = dto.CompanyName,
            Cnpj = dto.Cnpj
        };

        return await _repository.Create(legalEntity);
    }

    public async Task<bool> Delete(long id)
    {
        return await _repository.Delete(id);
    }

    public async Task<List<LegalEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<LegalEntity?> GetById(long id)
    {
        return await _repository.GetById(id);
    }

    public async Task<LegalEntity?> Update(long id, UpdateLegalEntityDTO dto)
    {
        var legalEntity = await _repository.GetById(id);
        if (legalEntity == null)
        {
            return null;
        }

        if (!string.IsNullOrWhiteSpace(dto.Email))
        {
            legalEntity.Email = dto.Email;
        } if (!string.IsNullOrWhiteSpace(dto.Phone))
        {
            legalEntity.Phone = dto.Phone;
        } if (!string.IsNullOrWhiteSpace(dto.BusinessName))
        {
            legalEntity.BusinessName = dto.BusinessName;
        } if (!string.IsNullOrWhiteSpace(dto.CompanyName))
        {
            legalEntity.CompanyName = dto.CompanyName;
        }

        legalEntity.UpdatedAt = DateTime.UtcNow;

        return await _repository.Update(legalEntity);
    }
}