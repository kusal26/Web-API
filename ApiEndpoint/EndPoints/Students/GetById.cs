using ApiEndpoint.Data;
using ApiEndpoint.DTO;
using ApiEndpoint.Models;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.EndPoints.Students
{
    public class GetById : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<Student>
    {
        private readonly DataContext _context;
        public GetById(DataContext context)
        {
            _context = context;
        }
        [HttpPost("GetById")]
        public override async Task<ActionResult<Student>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            var result = await _context.Students.FindAsync(request);
            if (result != null)
            {

                return Ok(result);
            }
            else
            {
                return Content("Id Not Found");
            }
          
        }
      
    }
}
