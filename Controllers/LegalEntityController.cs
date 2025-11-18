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
using api.DTOs.LegalEntity;
using api.DTOs.Client;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalEntityController : ControllerBase
    {
        private readonly ILegalEntityService _service;

        public LegalEntityController(ILegalEntityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalEntity>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LegalEntity?>> GetById(long id)
        {
            var legalEntity = await _service.GetById(id);
            if (legalEntity == null)
            {
                return NotFound("Legal entity not found");
            }

            return Ok(legalEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateLegalEntityDTO dto)
        {
            var legalEntity = await _service.Update(id, dto);
            if (legalEntity == null)
            {
                return NotFound("Legal entity not found");   
            }

            return Ok(legalEntity);
        }

        [HttpPost]
        public async Task<ActionResult<LegalEntity>> Create(CreateLegalEntityDTO dto)
        {
            var legalEntity = await _service.Create(dto);
            return CreatedAtAction(
                nameof(GetById),
                new { id = legalEntity.Id },
                legalEntity
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var legalEntity = await _service.Delete(id);
            if (!legalEntity)
            {
                return NotFound("Legal entity not found");
            }

            return NoContent();
        }

        [HttpPost("{id}/phones")]
        public async Task<IActionResult> CreatePhone(long id, CreatePhoneDTO dto)
        {
            var legalEntity = await _service.AddPhone(id, dto);
            return Ok();
        }

    }
}
