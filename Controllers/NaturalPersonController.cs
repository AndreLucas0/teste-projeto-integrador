using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api.Interfaces.Services;
using api.DTOs.NaturalPerson;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturalPersonController : ControllerBase
    {
        private readonly INaturalPersonService _service;

        public NaturalPersonController(INaturalPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaturalPerson>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<NaturalPerson>> GetById(long id)
        {
            var naturalPerson = await _service.GetById(id);
            if (naturalPerson == null)
            {
                return NotFound("Natural person not found");
            }

            return Ok(naturalPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateNaturalPersonDTO dto)
        {
            var naturalPerson = await _service.Update(id, dto);
            if (naturalPerson == null)
            {
                return NotFound("Natural person not found");
            }

            return Ok(naturalPerson);
        }

        [HttpPost]
        public async Task<ActionResult<NaturalPerson>> Create(CreateNaturalPersonDTO dto)
        {
            var naturalPerson = await _service.Create(dto);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id = naturalPerson.Id },
                naturalPerson
            );
        }

        // DELETE: api/NaturalPerson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaturalPerson(long id)
        {
            var naturalPerson = await _service.Delete(id);
            if (!naturalPerson)
            {
                return NotFound("Natural person not found");
            }

            return NoContent();
        }
    }
}
