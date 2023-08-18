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
    public class MovieHallsController : ControllerBase
    {
        private readonly DataContext _context;

        public MovieHallsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MovieHalls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieHall>>> GetMovieHall()
        {
          if (_context.MovieHall == null)
          {
              return NotFound();
          }
            return await _context.MovieHall.ToListAsync();
        }

        // GET: api/MovieHalls/5
        [HttpGet("GetbyId")]
        public async Task<ActionResult<MovieHall>> GetMovieHall(int id)
        {
          if (_context.MovieHall == null)
          {
              return NotFound();
          }
            var movieHall = await _context.MovieHall.FindAsync(id);

            if (movieHall == null)
            {
                return NotFound();
            }

            return movieHall;
        }

        // PUT: api/MovieHalls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update")]
        public async Task<IActionResult> PutMovieHall(int id, MovieHall movieHall)
        {
            if (id != movieHall.HallId)
            {
                return BadRequest();
            }

            if (movieHall.TotalSeat != 0)
            {
            _context.Entry(movieHall).State = EntityState.Modified;
            

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieHallExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Content("Updated");
               
            }
            else
            {

                return Content("Seat Cannot be 0");
            }

        }

        
        [HttpPost]
        [Route("AddHall")]
        public async Task<ActionResult<MovieHall>> PostMovieHall(MovieHall movieHall)
        {
          if (_context.MovieHall == null)
          {
              return Problem("Entity set 'DataContext.MovieHall'  is null.");
          }
          if( movieHall.TotalSeat!=0)
            { 
                _context.MovieHall.Add(movieHall);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovieHall", new { id = movieHall.HallId }, movieHall);

            }
            return Problem("Seat should not be 0");


        }

        // DELETE: api/MovieHalls/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMovieHall(int id)
        {
            if (_context.MovieHall == null)
            {
                return NotFound();
            }
            var movieHall = await _context.MovieHall.FindAsync(id);
            if (movieHall == null)
            {
                return NotFound();
            }

            _context.MovieHall.Remove(movieHall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieHallExists(int id)
        {
            return (_context.MovieHall?.Any(e => e.HallId == id)).GetValueOrDefault();
        }
    }
}
