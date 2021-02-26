using System;

namespace MoviesAPI.DTOs
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration{ get; set; }
    }
}