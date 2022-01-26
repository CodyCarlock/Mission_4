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

        //seeding database with three movies
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<applicationResponse>().HasData(

                new applicationResponse
                { 
                    MovieId = 1,
                    Category = "Action/Adventure",
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
                    Category = "Action/Adventure",
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
                    Category = "Family",
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
