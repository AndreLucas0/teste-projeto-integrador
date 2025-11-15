using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalEntityController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public LegalEntityController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/LegalEntity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LegalEntity>>> GetLegalEntity()
        {
            return await _context.LegalEntity.ToListAsync();
        }

        // GET: api/LegalEntity/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LegalEntity>> GetLegalEntity(long id)
        {
            var legalEntity = await _context.LegalEntity.FindAsync(id);

            if (legalEntity == null)
            {
                return NotFound();
            }

            return legalEntity;
        }

        // PUT: api/LegalEntity/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLegalEntity(long id, LegalEntity legalEntity)
        {
            if (id != legalEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(legalEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LegalEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LegalEntity
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LegalEntity>> PostLegalEntity(LegalEntity legalEntity)
        {
            _context.LegalEntity.Add(legalEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLegalEntity", new { id = legalEntity.Id }, legalEntity);
        }

        // DELETE: api/LegalEntity/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLegalEntity(long id)
        {
            var legalEntity = await _context.LegalEntity.FindAsync(id);
            if (legalEntity == null)
            {
                return NotFound();
            }

            _context.LegalEntity.Remove(legalEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LegalEntityExists(long id)
        {
            return _context.LegalEntity.Any(e => e.Id == id);
        }
    }
}
