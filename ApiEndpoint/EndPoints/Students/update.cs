using ApiEndpoint.Data;
using ApiEndpoint.DTO;
using ApiEndpoint.Models;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.EndPoints.Students
{
    public class updateRequest
    {
        [FromRoute]
        public int Id { get; set; }
        [FromBody]
        public StudentCommandDTO? Command { get; set; }
    }

    public class Update : EndpointBaseAsync
        .WithRequest<updateRequest>
        .WithActionResult<Student>
    {
        private readonly DataContext _context;
        public Update(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("update")]
        public override async Task<ActionResult<Student>> HandleAsync(updateRequest request, CancellationToken cancellationToken = default)
        {
            var result= await _context.Students.FindAsync(request.Id);
            if (result != null)
            {



                result.Address = request.Command.Address;
                result.RollNo = request.Command.RollNo;
                result.Name = request.Command.Name;
                result.Grade = request.Command.Grade;





                _context.Students.Update(result);
                _context.SaveChanges();
            }
            else
            {
                return Content("Not Found");
            }
            return Ok(result);



        }
    }
}
