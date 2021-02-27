using System;
using System.ComponentModel.DataAnnotations;
using MoviesAPI.Entities;

namespace MoviesAPI.DTOs
{
    public class MoviePatchDTO 
    {
        [Required] public string Title { get; set; }
        public string Summary { get; set; }
        public bool InTheaters { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}