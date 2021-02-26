namespace MoviesAPI.DTOs
{
    public class FilterMoviesDTO
    {
        public int Page { get; set; } = 1;
        public int RecordPerPage { get; set; } = 10;

        public PaginationDTO Pagination
        {
            get { return new PaginationDTO() {Page = Page, RecordsPerPage = RecordPerPage}; }
        }

        public string Title { get; set; }
        public int GenreId { get; set; }
        public bool InTheaters { get; set; }
        public bool UpcommignReelase { get; set; }
        public string OrderingField { get; set; }
        public bool AccendingOrder { get; set; } = true;
    }
}