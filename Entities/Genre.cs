using MoviesAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class Genre
    {
        [Key] public int Id { get; set; }

        [Required]
        [StringLength(40)]
      
        public string Name { get; set; }

        public List<MovieGenres> MovieGenres { get; set; }
    }
}