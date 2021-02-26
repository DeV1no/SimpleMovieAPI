using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class UserInfo
    {
        [Required] [EmailAddress] public string EmailAddress { get; set; }
        [Required] public string Password { get; set; }
    }
}