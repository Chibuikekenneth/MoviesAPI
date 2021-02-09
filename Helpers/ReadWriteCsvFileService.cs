using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using MoviesAPI.Mappers;
using MoviesAPI.Models.Entities;

namespace MoviesAPI.Helpers
{
    public class ReadWriteCsvFileService
    {
        public List < MetaData > ReadMetaDataCSVFile(string location) 
        {  
            try {  
                using(var reader = new StreamReader(location, Encoding.Default))  
                using(var csv = new CsvReader(reader)) {  
                    csv.Configuration.RegisterClassMap < MetaDataMap > ();  
                    var records = csv.GetRecords < MetaData > ().ToList();  
                    return records;  
                }  
            } catch (Exception e) {  
                throw new Exception(e.Message);  
            }  
        }  

        public List < Stats > ReadStatsCSVFile(string location) 
        {  
            try {  
                using(var reader = new StreamReader(location, Encoding.Default))  
                using(var csv = new CsvReader(reader)) {  
                    csv.Configuration.RegisterClassMap < StatsMap > ();  
                    var records = csv.GetRecords < Stats > ().ToList();  
                    return records;  
                }  
            } catch (Exception e) {  
                throw new Exception(e.Message);  
            }  
        }  
    }
}