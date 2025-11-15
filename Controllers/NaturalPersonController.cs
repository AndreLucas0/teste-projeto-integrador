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
    public class NaturalPersonController : ControllerBase
    {
        private readonly BackEndAPIContext _context;

        public NaturalPersonController(BackEndAPIContext context)
        {
            _context = context;
        }

        // GET: api/NaturalPerson
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NaturalPerson>>> GetNaturalPerson()
        {
            return await _context.NaturalPerson.ToListAsync();
        }
    
        // GET: api/NaturalPerson/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NaturalPerson>> GetNaturalPerson(long id)
        {
            var naturalPerson = await _context.NaturalPerson.FindAsync(id);

            if (naturalPerson == null)
            {
                return NotFound();
            }

            return naturalPerson;
        }

        // PUT: api/NaturalPerson/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNaturalPerson(long id, NaturalPerson naturalPerson)
        {
            if (id != naturalPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(naturalPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturalPersonExists(id))
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

        // POST: api/NaturalPerson
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NaturalPerson>> PostNaturalPerson(NaturalPerson naturalPerson)
        {
            _context.NaturalPerson.Add(naturalPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNaturalPerson", new { id = naturalPerson.Id }, naturalPerson);
        }

        // DELETE: api/NaturalPerson/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNaturalPerson(long id)
        {
            var naturalPerson = await _context.NaturalPerson.FindAsync(id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            _context.NaturalPerson.Remove(naturalPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NaturalPersonExists(long id)
        {
            return _context.NaturalPerson.Any(e => e.Id == id);
        }
    }
}
