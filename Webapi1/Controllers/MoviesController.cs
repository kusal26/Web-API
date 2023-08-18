using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapi1.Models;

namespace Webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly DataContext _context;

        public MoviesController(DataContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movies>>> GetMovies()
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            return await _context.Movies.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("GetMovies")]
        public async Task<ActionResult<Movies>> GetMovies(int id)
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            var movies = await _context.Movies.FindAsync(id);

            if (movies == null)
            {
                return NotFound();
            }

            return movies;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update")]
        public async Task<IActionResult> PutMovies(int id, Movies movies)
        {
            if (id != movies.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoviesExists(id))
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

        
        [HttpPost]
        [Route("AddMovies")]
        public async Task<ActionResult<Movies>> PostMovies(Movies movies)
        {
          if (_context.Movies == null)
          {
              return Problem("Entity set 'DataContext.Movies'  is null.");
          }
            _context.Movies.Add(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovies", new { id = movies.MovieId }, movies);
        }

        // DELETE: api/Movies/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMovies(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movies = await _context.Movies.FindAsync(id);
            if (movies == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movies);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoviesExists(int id)
        {
            return (_context.Movies?.Any(e => e.MovieId == id)).GetValueOrDefault();
        }
    }
}
