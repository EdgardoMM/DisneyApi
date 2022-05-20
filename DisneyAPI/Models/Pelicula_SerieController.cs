using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DisneyAPI.Data;

namespace DisneyAPI.Models
{
    [Route("[controller]")]
    [ApiController]
    public class Pelicula_SerieController : ControllerBase
    {
        private readonly DisneyAPIContext _context;

        public Pelicula_SerieController(DisneyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pelicula_Serie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula_Serie>>> GetPelicula_Serie()
        {
            return await _context.Pelicula_Serie.ToListAsync();
        }

        // GET: api/Pelicula_Serie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula_Serie>> GetPelicula_Serie(int id)
        {
            var pelicula_Serie = await _context.Pelicula_Serie.FindAsync(id);

            if (pelicula_Serie == null)
            {
                return NotFound();
            }

            return pelicula_Serie;
        }

        // PUT: api/Pelicula_Serie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPelicula_Serie(int id, Pelicula_Serie pelicula_Serie)
        {
            if (id != pelicula_Serie.Id)
            {
                return BadRequest();
            }

            _context.Entry(pelicula_Serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Pelicula_SerieExists(id))
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

        // POST: api/Pelicula_Serie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pelicula_Serie>> PostPelicula_Serie(Pelicula_Serie pelicula_Serie)
        {
            _context.Pelicula_Serie.Add(pelicula_Serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPelicula_Serie", new { id = pelicula_Serie.Id }, pelicula_Serie);
        }

        // DELETE: api/Pelicula_Serie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula_Serie(int id)
        {
            var pelicula_Serie = await _context.Pelicula_Serie.FindAsync(id);
            if (pelicula_Serie == null)
            {
                return NotFound();
            }

            _context.Pelicula_Serie.Remove(pelicula_Serie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Pelicula_SerieExists(int id)
        {
            return _context.Pelicula_Serie.Any(e => e.Id == id);
        }
    }
}
