using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.models;
using MovieLibrary.Exceptions;
using MovieLibrary.Services;
using System.Diagnostics.Eventing.Reader;

namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        public static List<Movie> movies = new List<Movie>(5); //list initilization improves performance
                                                        //It reduces the frequency of reallocations and copying when adding elements.
        public MovieManager() {
            movies = DataSerializer.DeserializeMovieList();
        }

        public static void AddNewMovie(int id, string name, int year, string genre)
        {
            if (movies.Count >= 5)
            {
                throw new CapacityFullExceptionException("Sorry, you cannot add more movies. Movie list is full.\n");
            }
           
            if (id <= 0)
                throw new InvalidMovieIdException("Invalid movie Id. Id must be greater than 0.\n");

            int parsedGenre;
            if (int.TryParse(genre, out parsedGenre)) //here tryparse required the val i.e converted to be stored hence out varname is used to store
            {
                throw new InvalidMovieGenreException("Invalid movie genre. It should not be number.\n");
            }
            else {
                // Create a new Movie instance and add it to the movies list
                Movie newMovie = new Movie(id, name, year, genre);
                movies.Add(newMovie);
            }
         
        }


        public static List<Movie> DisplayMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreIsEmptyException("Movie store is Empty!\n");
            else
                return movies;
        }

        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            if (id <= 0)
            {
                throw new InvalidMovieIdException("Invalid movie Id. Id must be greater than 0");
            }
            //foreach(Movie movie in movies)
            //{
            //    if(movie.Id == id)
            //        findMovie = movie;
            //}
            //linq
            findMovie = movies.Where(item => item.Id == id).FirstOrDefault();
            if (findMovie != null)
                return findMovie;
            else
                throw new MovieNotFoundException("Movie not found!\n");
        }

        public static void RemoveMovieById(int id)
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
            {
                throw new MovieNotFoundException("Movie not found\n");
            }
            else
                movies.Remove(findMovie); 

        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreIsEmptyException("Movie Store is already Empty!\n");

            movies.Clear();
        }

        public static void ExitMovieStore()
        {
            DataSerializer.SerializeMovieList(movies);
        }
    }
}
//crud operations

