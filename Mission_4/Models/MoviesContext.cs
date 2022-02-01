using Microsoft.EntityFrameworkCore;
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
        public DbSet<Mission_4.Models.Categories> Categories { get; set; }

        //seeding database with three movies
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Mission_4.Models.Categories>().HasData(
                    new Mission_4.Models.Categories { CategoryID=1, CategoryName= "Action/Adventure" },
                    new Mission_4.Models.Categories { CategoryID=2, CategoryName= "Comedy" },
                    new Mission_4.Models.Categories { CategoryID = 3, CategoryName = "Drama" },
                    new Mission_4.Models.Categories { CategoryID = 4, CategoryName = "Family" },
                    new Mission_4.Models.Categories { CategoryID = 5, CategoryName = "Horror/Suspense" },
                    new Mission_4.Models.Categories { CategoryID = 6, CategoryName = "Miscellaneous" },
                    new Mission_4.Models.Categories { CategoryID = 7, CategoryName = "Romance" },
                    new Mission_4.Models.Categories { CategoryID = 8, CategoryName = "Television" },
                    new Mission_4.Models.Categories { CategoryID = 9, CategoryName = "VHS" }
                );


            mb.Entity<applicationResponse>().HasData(

                new applicationResponse
                { 
                    MovieId = 1,
                    CategoryID = 1,
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
                    CategoryID = 1,
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
                    CategoryID = 4,
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
