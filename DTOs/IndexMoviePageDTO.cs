using System.Collections.Generic;

namespace MoviesAPI.DTOs
{
    public class IndexMoviePageDTO
    {
        public List<MovieDTO> UpCommingReleases { get; set; }
        public List<MovieDTO> InTheaters { get; set; }
    }
}