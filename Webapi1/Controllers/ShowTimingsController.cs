using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using Webapi1.Models;

namespace Webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingsController : ControllerBase
    {
        private readonly DataContext _context;

        public ShowTimingsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ShowTimings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowTiming>>> GetShowTiming()
        {
          if (_context.ShowTiming == null)
          {
              return NotFound();
          }
            return await _context.ShowTiming.Include(x=>x.Movies).Include(y=>y.MovieHall).ToListAsync();
        }

        // GET: api/ShowTimings/5
        [HttpGet("GetById")]
        public async Task<ActionResult<ShowTiming>> GetShowTiming(int id)
        {
          if (_context.ShowTiming == null)
          {
              return NotFound();
          }
            var showTiming = await _context.ShowTiming.FindAsync(id);

            if (showTiming == null)
            {
                return NotFound();
            }

            return showTiming;
        }

        // PUT: api/ShowTimings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update")]
        public async Task<IActionResult> PutShowTiming(int id, ShowTiming showTiming)
        {
            if (id != showTiming.TimingId)
            {
                return BadRequest();
            }

            _context.Entry(showTiming).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowTimingExists(id))
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
        [Route("AddShow")]
        public async Task<ActionResult<ShowTiming>> PostShowTiming(ShowTimingDTO showTimingDTO)
        {
         
    
           
   
    
        ShowTiming showTiming =new ShowTiming()
        {
            HallId = showTimingDTO.HallId,
            MovieId = showTimingDTO.MovieId,
            show_datetime=showTimingDTO.show_datetime,
            available_seats = showTimingDTO.available_seats,

        };

         
            _context.ShowTiming.Add(showTiming);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShowTiming", new { id = showTiming.TimingId }, showTiming);
        }

        // DELETE: api/ShowTimings/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteShowTiming(int id)
        {
            if (_context.ShowTiming == null)
            {
                return NotFound();
            }
            var showTiming = await _context.ShowTiming.FindAsync(id);
            if (showTiming == null)
            {
                return NotFound();
            }

            _context.ShowTiming.Remove(showTiming);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowTimingExists(int id)
        {
            return (_context.ShowTiming?.Any(e => e.TimingId == id)).GetValueOrDefault();
        }
    }
}
