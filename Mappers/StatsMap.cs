using CsvHelper.Configuration;
using MoviesAPI.Models.Entities;

namespace MoviesAPI.Mappers
{
    public class StatsMap : ClassMap <Stats>
    {
        public StatsMap()
        {
            Map(x => x.MovieId).Name("MovieId");  
            Map(x => x.WatchDurationMs).Name("WatchDurationMs");
        }
    }
}