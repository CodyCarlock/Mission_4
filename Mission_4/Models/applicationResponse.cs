using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class applicationResponse
    {
        //makes it so that a movie ID is required and the Primary key
        [Key]
        [Required]
        public int MovieId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent_To { get; set; }
        public string Notes { get; set; }

        

    }
}
