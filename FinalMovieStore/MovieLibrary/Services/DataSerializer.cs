using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieLibrary.models;

namespace MovieLibrary.Services
{
    internal class DataSerializer
    {
        //static string path = ConfigurationManager.AppSettings["filePath"].ToString();
        static string path = @"D:\Assignments\MovieStore_MiniProject\FinalMovieStore\MovieLibrary\Assets\myMovies.json";
        public static void SerializeMovieList(List<Movie> movies)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movies));

            }
        }

        public static List<Movie> DeserializeMovieList()
        {
            if (!File.Exists(path))
                return new List<Movie>();

            using (StreamReader sr = new StreamReader(path))
            {
                List<Movie> movies = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return movies;
            }
        }
    }
}
