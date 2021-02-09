using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Helpers;
using MoviesAPI.Models;
using MoviesAPI.Models.Entities;
using MoviesAPI.Models.InputModels;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        //Temporary database
        public List<MetaData> database { get; set; }
        public readonly ReadWriteCsvFileService _readWriteCsvFileService;
        public const string MetaDataFilePath = @"metadata.csv";
        public const string StatsFilePath = @"stats.csv";

        public MovieController(ReadWriteCsvFileService readWriteCsvFileService)
        {
            this.database = new List<MetaData>();
            _readWriteCsvFileService = readWriteCsvFileService;
        }

        /// <summary>
        /// Endpoint to Save a new piece of metadata
        /// </summary>
        /// <returns></returns>
        [HttpPost("metadata")]
        public ActionResult<List<MetaData>> SaveMetaData([FromBody] MetaDataInputModel model)
        {  
            var metaData = new MetaData
            {
                MovieId = model.MovieId,
                Title = model.Title,
                Language = model.Language,
                Duration = model.Duration,
                ReleaseYear = model.ReleaseYear
            };
            
            //save to tmporary database 
            database.Add(metaData);
            return database;
        }

        /// <summary>
        /// Endpoint to return all metadata for a given movie.
        /// </summary>
        /// <returns></returns>
        [HttpGet("metadata/:movieId")]
        public ActionResult<List<MetaData>> GetMetaDataByMovieId([FromHeader] int movieId)
        {
            var metadatas = _readWriteCsvFileService.ReadMetaDataCSVFile(MetaDataFilePath);
            var csvData = metadatas.Where(x => x.MovieId == movieId);
            if (csvData == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var result =  csvData.GroupBy(x => x.Language)
                                    .Select(t => t.OrderByDescending(c => c.Id)
                                    .FirstOrDefault())
                                    .ToList();
            return result;
        }
        
        // /// <summary>
        // /// Endpoint to return the viewing statistics for all movies
        // /// </summary>
        // /// <returns></returns>
        // [HttpGet("stats")]
        // public async Task<ActionResult> GetViewingStatistics()
        // {
        //     //To get Statistics
        //     var statsDatas = _readWriteCsvFileService.ReadStatsCSVFile(StatsFilePath);
        //     var metadatas = _readWriteCsvFileService.ReadMetaDataCSVFile(MetaDataFilePath);

        // }
    }
}
