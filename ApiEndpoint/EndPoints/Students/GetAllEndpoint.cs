using ApiEndpoint.Data;
using ApiEndpoint.Models;
using Ardalis.ApiEndpoints;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using OpenTracing.Tag;
using static Ardalis.ApiEndpoints.EndpointBaseAsync.WithoutRequest;

namespace ApiEndpoint.EndPoints.Students
{
    public class GetAllEndpoint : EndpointBaseSync
        .WithoutRequest
        .WithActionResult<IEnumerable<Student>>    
    {

        private readonly DataContext _context;
        public GetAllEndpoint(DataContext context)
        {
            _context = context;
        }
        [HttpGet("Student")]
        
        public override ActionResult<IEnumerable<Student>> Handle()
        {
            var result=_context.Students.ToList();
            if(result.Count==0)
            {
                return Content("Empty Result");
            }
            return Ok(result);
        }
    }
}
