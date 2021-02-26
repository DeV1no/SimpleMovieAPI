using System.Collections.Generic;

namespace MoviesAPI.DTOs
{
    public class MovieDetailsDTO:MovieDTO
    {
        public List<GenreDTO> Genres { get; set; }
        public List<ActorShowDTO> Actors { get; set; }
    }
}