namespace MoviesAPI.Models.InputModels
{
    public class MetaDataInputModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public int ReleaseYear { get; set; }
    }
}
