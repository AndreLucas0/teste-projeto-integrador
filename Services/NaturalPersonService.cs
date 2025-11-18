// using System.Threading.Tasks;
// using api.Data;
// using api.DTOs.LegalEntity;
// using api.DTOs.NaturalPerson;
// using api.Interfaces.Repositories;
// using api.Interfaces.Services;
// using api.Models;
// using api.Repositories;
// using Microsoft.EntityFrameworkCore;

// namespace api.Services;

// public class NaturalPersonService : INaturalPersonService
// {

//     private readonly INaturalPersonRepository _repository;

//     public NaturalPersonService(INaturalPersonRepository repository)
//     {
//         _repository = repository;
//     }

//     public async Task<NaturalPerson> Create(CreateNaturalPersonDTO dto)
//     {
//         var naturalPerson = new NaturalPerson
//         {
//             Email = dto.Email,
//             Phone = dto.Phone,
//             CreatedAt = DateTime.UtcNow,
//             UpdatedAt = DateTime.UtcNow,
//             Name = dto.Name,
//             Cpf = dto.Cpf,
//             Birth = dto.Birth
//         };

//         return await _repository.Create(naturalPerson);
//     }

//     public async Task<bool> Delete(long id)
//     {
//         return await _repository.Delete(id);
//     }

//     public async Task<List<NaturalPerson>> GetAll()
//     {
//         return await _repository.GetAll();
//     }

//     public async Task<NaturalPerson?> GetById(long id)
//     {
//         return await _repository.GetById(id);
//     }

//     public async Task<NaturalPerson?> Update(long id, UpdateNaturalPersonDTO dto)
//     {
//         var naturalPerson = await _repository.GetById(id);
//         if (naturalPerson == null)
//         {
//             return null;
//         }

//         if (!string.IsNullOrWhiteSpace(dto.Email))
//         {
//             naturalPerson.Email = dto.Email;
//         } if (!string.IsNullOrWhiteSpace(dto.Phone))
//         {
//             naturalPerson.Phone = dto.Phone;
//         } if (!string.IsNullOrWhiteSpace(dto.Name))
//         {
//             naturalPerson.Name = dto.Name;
//         }

//         naturalPerson.UpdatedAt = DateTime.UtcNow;

//         return await _repository.Update(naturalPerson);
//     }
// }