using System;
using System.ComponentModel.DataAnnotations;
using MoviesAPI.Entities;

namespace MoviesAPI.DTOs
{
    public class PersonPatchDTO : IId
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}