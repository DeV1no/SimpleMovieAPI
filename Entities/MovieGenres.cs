namespace MoviesAPI.Entities
{
    public class MovieGenres
    {
        public int MovieId { get; set; }
        public int GenresId { get; set; }
        public Genre Genre { get; set; }
        public Movie Movie { get; set; }
    }
}