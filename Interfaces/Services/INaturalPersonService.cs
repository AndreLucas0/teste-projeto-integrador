using api.DTOs.NaturalPerson;
using api.Models;

namespace api.Interfaces.Services;

public interface INaturalPersonService
{
    Task<List<NaturalPerson>> GetAll();
    Task<NaturalPerson?> GetById(long id);
    Task<NaturalPerson> Create(CreateNaturalPersonDTO dto);
    Task<NaturalPerson?> Update(long id, UpdateNaturalPersonDTO dto);
    Task<bool> Delete(long id);
}