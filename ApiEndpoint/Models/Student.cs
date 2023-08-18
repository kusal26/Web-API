using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ApiEndpoint.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public int RollNo { get; set; }
        public int Grade { get; set; }
            
        public string? Address { get; set; }
        
    }
}
