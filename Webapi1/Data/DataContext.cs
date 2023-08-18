using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webapi1.Models;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Webapi1.Models.Movies> Movies { get; set; } = default!;

        public DbSet<Webapi1.Models.MovieHall> MovieHall { get; set; } = default!;

        public DbSet<Webapi1.Models.ShowTiming> ShowTiming { get; set; } = default!;
        public DbSet<Webapi1.Models.BookedMOdel>? BookedModels { get; set; } = default!;
}
