using System.Threading.Tasks;
using api.Data;
using api.DTOs.Client;
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

        if (!string.IsNullOrWhiteSpace(dto.BusinessName))
        {
            legalEntity.BusinessName = dto.BusinessName;
        } if (!string.IsNullOrWhiteSpace(dto.CompanyName))
        {
            legalEntity.CompanyName = dto.CompanyName;
        }

        legalEntity.UpdatedAt = DateTime.UtcNow;

        return await _repository.Update(legalEntity);
    }

    public async Task<LegalEntity?> AddPhone(long id, CreatePhoneDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var phone = new Phone {
            Number = dto.Number,
            Client = legalEntity
        };

        legalEntity.AddPhone(phone);
        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> RemovePhone(long id, long phoneId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        legalEntity.RemovePhone(phoneId);
        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> UpdatePhone(long id, long phoneId, UpdatePhoneDTO dto)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        var phone = legalEntity.GetPhoneById(phoneId);
        if (phone == null)
        {
            return null;
        }
        if (!string.IsNullOrWhiteSpace(dto.Number))
        {
            phone.Number = dto.Number;
        }
        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> AddEmail(long id, Email email)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        legalEntity.AddEmail(email);
        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> RemoveEmail(long id, long emailId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        legalEntity.RemoveEmail(emailId);
        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> AddAddress(long id, Address address)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        legalEntity.AddAddress(address);
        return await _repository.Save(legalEntity);
    }

    public async Task<LegalEntity?> RemoveAddress(long id, long addressId)
    {
        var legalEntity = await GetById(id);
        if (legalEntity == null)
        {
            return null;
        }
        legalEntity.RemoveAddress(addressId);
        return await _repository.Save(legalEntity);
    }
}