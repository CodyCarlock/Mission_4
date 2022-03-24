using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Mission_4.Models;

namespace Mission4.Models
{
    public class applicationResponse
    {
        //makes it so that a movie ID is required and the Primary key
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required(ErrorMessage ="Please enter a Movie Title")]
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent_To { get; set; }
        public string Notes { get; set; }

        //building foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }



    }
}
