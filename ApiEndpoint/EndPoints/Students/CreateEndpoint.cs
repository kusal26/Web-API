using ApiEndpoint.Data;
using ApiEndpoint.DTO;
using ApiEndpoint.Models;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.EndPoints.Students
{
    public class CreateEndpoint:EndpointBaseAsync
        .WithRequest<StudentCommandDTO>
        .WithActionResult
    {

        private readonly DataContext _context;
    
        public CreateEndpoint(DataContext context)
        {
            _context = context;
          
        }
      


       
        [HttpPost("PostStudent")]

        public async override Task<ActionResult> HandleAsync(StudentCommandDTO request, CancellationToken cancellationToken = default)
        {
            Student data = new Student()
            {
                Name = request.Name,
                Address = request.Address,
                RollNo = request.RollNo,
                Grade = request.Grade
            };

           await _context.Students.AddAsync(data);
           await _context.SaveChangesAsync();
            return Ok(request);
        }
    }
}
