using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLists
{
    class Program
    {
        public static List<Movie> myMovies = new List<Movie>()
        {
                new Movie("Bambi","animated"),
                new Movie("Peter Pan","animated"),
                new Movie("Shininh","horror"),
                new Movie("IT","horror"),
                new Movie("Get Out","horror"),
                new Movie("The Godfather","drama"),
                new Movie("Pulp Fiction","drama"),
                new Movie("Star Wars","scifi"),
                new Movie("Blade Runner","scifi"),
                new Movie("Ready Player One","scifi"),

        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Movie List Application\n\n" +
                              "There are 10 quality movies in this list. ");
            do
            {
                Update();
            }
            while (GoAgain());

        }

        public static void Update()
        {
            DisplayCategory(GetCategory());
        }

        public static string GetCategory()
        {
            Console.Write("What category are you interested in?: ");
            string input = Console.ReadLine().ToLower().Trim();
            if (input.Any())
            {
                return input;
            }
            else
            {
                Console.WriteLine("No category detected, please try again.");
                GetCategory();
            }
            return input; // do not know more meaningful way to make compiler stop complaining
        }

        public static void DisplayCategory(string s)
        {
            bool foundMovie = false;
            for(int i = 0; i<myMovies.Count;i++)
            {
                if(myMovies[i].Category == s)
                {
                    Console.WriteLine(myMovies[i].Title);
                    foundMovie = true;
                }
            }

            if(!foundMovie)
            {
                Console.WriteLine($"Sorry, no movie of the {s} category was found");
            }
        }
        // identifies if the user wants to continue to get info
        public static bool GoAgain()
        {
            Console.WriteLine();
            Console.Write("Would you like to learn more? (enter \"yes\" or \"no\"): ");
            string input = Console.ReadLine().ToLower().Trim();
            try
            {
                if (input != "yes")
                {
                    if (input != "no")
                    {
                        throw new Exception("Invalid response, please try again");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                GoAgain();
            }

            if (input == "yes")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Goodbye");
                return false;
            }
        }
    }
}
