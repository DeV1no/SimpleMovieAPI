using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class GenreCreationDTO
    {
        [Key] public int Id { get; set; }

        [Required]
        [StringLength(40)]
      
        public string Name { get; set; }
    }
}