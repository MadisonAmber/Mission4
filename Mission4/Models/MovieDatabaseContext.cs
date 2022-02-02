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
        // Call the variable the plural version of the model name.
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Action"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Romance"
                }
            );

            mb.Entity<Movie>().HasData(

                new Movie
                {
                    Id = 1,
                    Title = "Catch Me If You Can",
                    CategoryID = 1,
                    Year = 2002,
                    Director = "Stephen Spielberg",
                    Rating = "PG-13"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Now You See Me",
                    CategoryID = 2,
                    Year = 2013,
                    Director = "Louis Leterrier",
                    Rating = "PG-13"
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Scarlet Pimpernel",
                    CategoryID = 3,
                    Year = 1982,
                    Director = "Clive Donner",
                    Rating = "PG"
                }
            );
        }
    }
}
