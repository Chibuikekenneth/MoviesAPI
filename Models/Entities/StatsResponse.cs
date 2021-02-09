namespace MoviesAPI.Models.Entities
{
    public class StatsResponse
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int AverageWatchDuration { get; set; }
        public int watches { get; set; }
        public int ReleaseYear { get; set; }
    }
}
