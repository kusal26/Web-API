using ApiEndpoint.Data;
using ApiEndpoint.Models;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.EndPoints.Students
{
    public class DeleteById : EndpointBaseAsync
        .WithRequest<int>
        .WithActionResult<Student>

    {
        private readonly DataContext _context;
        public DeleteById(DataContext context)
        {
            _context = context;
        }
        [HttpDelete("Delete")]
        public override async Task<ActionResult<Student>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            var result=await _context.Students.FindAsync(request, cancellationToken);
            if (result == null)
            {
                return Content("Id Not Found");
            }
            else
            {
                _context.Students.Remove(result);
                _context.SaveChanges();
            }
            return Ok(result);
        }
    }
}
