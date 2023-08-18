using ApiEndpoint.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEndpoint.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        public DbSet<Student> Students { get; set; }    

    }
}
