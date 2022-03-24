using Microsoft.EntityFrameworkCore;
using Mission_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MoviesContext: DbContext
    {
        //constructor 
        public MoviesContext (DbContextOptions<MoviesContext> options) : base(options)
        {
            //leave blank for now
        }

        public DbSet<applicationResponse> Responses { get; set; }
        public DbSet<Categories> Categories { get; set; }

        //seeding database with three movies
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Categories>().HasData(
                    new Categories { CategoryId = 1, CategoryName = "Action/Adventure" },
                    new Categories { CategoryId = 2, CategoryName = "Comedy" },
                    new Categories { CategoryId = 3, CategoryName = "Drama" },
                    new Categories { CategoryId = 4, CategoryName = "Family" },
                    new Categories { CategoryId = 5, CategoryName = "Horror/Suspense" },
                    new Categories { CategoryId = 6, CategoryName = "Miscellaneous" },
                    new Categories { CategoryId = 7, CategoryName = "Romance" },
                    new Categories { CategoryId = 8, CategoryName = "Television" },
                    new Categories { CategoryId = 9, CategoryName = "VHS" }
                );


            mb.Entity<applicationResponse>().HasData(

                new applicationResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Name = "Forest Gump",
                    Year = 1994,
                    Director = "Robert Zemeckis",
                    Rating = "PG-13",
                    Edited = true,
                    Notes = "Great"

                },
                new applicationResponse
                {
                    MovieId = 2,
                    CategoryId = 1,
                    Name = "Pulp Fiction",
                    Year = 1994,
                    Director = "Quentin Tarantino",
                    Rating = "R",
                    Edited = false,
                    Notes = "Great, but no Kids"
                },
                new applicationResponse
                {
                    MovieId = 3,
                    CategoryId = 4,
                    Name = "Togo",
                    Year = 2019,
                    Director = "Ericson Core",
                    Rating = "PG",
                    Edited = false,
                    Notes = "Dog & Alaska"
                }
             );
        }

    }
}
