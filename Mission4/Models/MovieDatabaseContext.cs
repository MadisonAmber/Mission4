using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieDatabaseContext : DbContext
    {
        // Constructor
        public MovieDatabaseContext (DbContextOptions<MovieDatabaseContext> options) : base (options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(

                new Movie
                {
                    Id = 1,
                    Title = "Catch Me If You Can",
                    Category = "Drama",
                    Year = 2002,
                    Director = "Stephen Spielberg",
                    Rating = "PG-13"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Now You See Me",
                    Category = "Thriller/Mystery",
                    Year = 2013,
                    Director = "Louis Leterrier",
                    Rating = "PG-13"
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Scarlet Pimpernel",
                    Category = "Romance/Adventure",
                    Year = 1982,
                    Director = "Clive Donner",
                    Rating = "PG"
                }
            ); ;
        }
    }
}
