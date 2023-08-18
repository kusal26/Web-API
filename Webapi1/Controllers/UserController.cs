using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using Webapi1.Models;



namespace Webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("Movies")]
        public IActionResult GetMovies()
        {
            var result = _context.Movies.ToList();
            if(result==null)
            {
                return Content("Not Available");
            }

            return Ok(result);
        }
        [HttpGet("Detail")]

        public IActionResult Details(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var result = _context.ShowTiming.Include(y=>y.Movies).Include(y=>y.MovieHall).FirstOrDefault(x => x.MovieId == id);

            return Ok(result);


        }

        [HttpPost]
        [Route("Buy Ticket")]
        public string Post(int id,ticketDto ticket)
        {
            if (ticket.NoOfticket == 0)
            {
                //ModelState.AddModelError("NoOfticket", "Select Ticket first");
                return "select Seat first";
            }
           
            var result = _context.ShowTiming.Include(x => x.Movies).Include(y => y.MovieHall).FirstOrDefault(x => x.TimingId == id);

            if (result != null)
            {
                if (ticket.NoOfticket > result?.available_seats)
                {
                    
                    return $"ticket unavailable\n available ticket={result.available_seats}";


                }
                else
                {
                    var total = ticket.NoOfticket * result.Movies.Price;
                    result.available_seats -= ticket.NoOfticket;
                    _context.ShowTiming.Update(result);
                    _context.SaveChanges();
                    var bookedticket = new BookedMOdel
                    { 
                       bookeddate = DateTime.Now,
                       MovieName=result.Movies.Name,
                       Noofticket=ticket.NoOfticket,
                       PricePerEach=result.Movies.Price,
                       Total= ticket.NoOfticket * result.Movies.Price,
                       Showdate=result.show_datetime,
                       HallName=result.MovieHall.HallName

                    };
                    _context.BookedModels.Add(bookedticket);
                    _context.SaveChanges();
                 


                }



            }
            else
            {
                return $"Id={id} doesnot Exist";
            }
            return $" MOvie Name={result.Movies.Name}\tHall Name={result.MovieHall.HallName}\t no of ticket={ticket.NoOfticket}\t Price Per Each={result.Movies.Price} \t Total={ticket.NoOfticket*result.Movies.Price } Booked date={DateTime.Now}";
           
        }
        [HttpGet]
        [Route("ticketDetails")]
        public List<BookedMOdel> TicketDetails()
        {
            return _context.BookedModels.ToList();
        }

      
    }
}
