using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Repository;

namespace MovieLibrary.ViewController
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            new MovieManager();

            while (true)
            {
                Console.WriteLine("==============WELCOME TO MOVIE STORE DEVELOPED BY: SHWETA================\n");
                Console.WriteLine("What would you like to do?\n");
                Console.WriteLine($"1.Add new Movie.\n" +
                     $"2.Display All Movies.\n" +
                     $"3.Find Movie by ID.\n" +
                     $"4.Remove Movie by ID.\n" +
                     $"5.Clear All Movies\n" +
                     $"6.Exit\n");

                int choice;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.WriteLine();
                    continue; // Skip the rest of the loop and prompt again
                }
                Console.WriteLine();
                try
                {
                    DoTask(choice);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Please enter numbers only!\n");
                }
                catch (CapacityFullExceptionException cf)
                {
                    Console.WriteLine(cf.Message);
                }
                catch (MovieNotFoundException mnf)
                {
                    Console.WriteLine(mnf.Message);
                }
                catch (MovieStoreIsEmptyException mse)
                {
                    Console.WriteLine(mse.Message);
                }
                catch (InvalidMovieIdException ime)
                {
                    Console.WriteLine(ime.Message);
                }
                catch (InvalidMovieGenreException img)
                {
                    Console.WriteLine(img.Message);
                }

            }
        }

        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    break;

                case 2:
                    Display();
                    break;

                case 3:
                    Find();
                    break;

                case 4:
                    Remove();
                    break;

                case 5:
                    Clear();
                    break;

                case 6:
                    MovieManager.ExitMovieStore();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input!\n");
                    break;

            }
        }

        static void Add()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Year Of Release: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Genre: ");
            string genre = Console.ReadLine();
            MovieManager.AddNewMovie(id, name, year, genre);

            Console.WriteLine("New Movie added successfully\n");
        }

        static void Display()
        {
            var movies = MovieManager.DisplayMovies();
            movies.ForEach(movie => Console.WriteLine(movie));
            //foreach(Movie movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}
            //linq
        }

        static void Find()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var movie = MovieManager.FindMovieById(id);
            Console.WriteLine(movie);
        }

        static void Remove()
        {
            Console.WriteLine("Enter Id: ");
            int id = Convert.ToInt32((Console.ReadLine()));
            MovieManager.RemoveMovieById(id);
            Console.WriteLine("Movie removed successfully!\n");
        }

        static void Clear()
        {
            MovieManager.ClearAllMovies();
            Console.WriteLine("Cleared successfully\n");
        }



    }
}



















//in display i have equated MovieManager.movies i.e list named as movies with var movies becoz 
//if i equate it with list<> then it will be equated to new list instead of that var will take ref from rhs and understand that it is list