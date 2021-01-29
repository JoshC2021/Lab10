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
                new Movie("The Shining","horror"),
                new Movie("IT","horror"),
                new Movie("Get Out","horror"),
                new Movie("The Godfather","drama"),
                new Movie("Pulp Fiction","drama"),
                new Movie("Star Wars","scifi"),
                new Movie("Blade Runner","scifi"),
                new Movie("Ready Player One","scifi"),
        };

        public static List<string> uniqueCategories = new List<string>();

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
            DisplayEachCategory();
            DisplayChosenMovies(GetCategory());
        }


        // grabs an integer from the user through exceptions
        // returns integer which is the index of the category in uniqueCategory list
        public static int GetCategory()
        {
           
            int categoryNumber = -1;
            bool needCategory = true;
            while (needCategory)
            {
                Console.Write("Please enter the number of the category you are interested in: ");
                string input = Console.ReadLine().ToLower().Trim();
                try
                {
                    if (input.Any()) // checks to see if user entered anything
                    {
                        categoryNumber = int.Parse(input) - 1;
                        if (categoryNumber >= uniqueCategories.Count || categoryNumber < 0) // choice has to be within range
                        {
                            throw new Exception("No category in that range, please try again.");
                        }
                    }
                    else
                    {
                        throw new Exception("No category detected, please try again.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a valid number, please try again");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                needCategory = false;
            }

            return categoryNumber;
        }

        // prints all of the movies of the chosen category to the console
        // uses built in sort method prior to printing to order the movies
        public static void DisplayChosenMovies(int c)
        {
            List<string> orderedMovies = new List<string>();
            for(int i = 0; i<myMovies.Count;i++)
            {
                if(myMovies[i].Category == uniqueCategories[c])
                {
                    orderedMovies.Add(myMovies[i].Title);
                }
            }

            orderedMovies.Sort();
            
            foreach(string s in orderedMovies)
            {
                Console.WriteLine(s);
            }
        }

        // builds a unique list of each category in movie library
        // then displays the categories to the user via the console
        public static void DisplayEachCategory()
        {
            bool doesExsist;
            // looks at each movie and sees if category is added to the unique list 
            // of all the categories yet and adds if not present
            for(int i = 0; i<myMovies.Count;i++)
            {
                doesExsist = false;
                for(int j = 0; j<uniqueCategories.Count;j++)
                {
                    if(uniqueCategories[j] == myMovies[i].Category)
                    {
                        doesExsist = true;
                    }
                }

                if(!doesExsist)
                {
                    uniqueCategories.Add(myMovies[i].Category);
                }
            }
            Console.WriteLine("\nThe list has the following categories: ");
            for(int i = 0; i< uniqueCategories.Count;i++)
            {
                Console.WriteLine($"{i+1}) {uniqueCategories[i]}");
            }
        }


        // identifies if the user wants to continue with format exceptions
        public static bool GoAgain()
        {
            
            bool needGo = true;
            while (needGo)
            {
                Console.WriteLine();
                Console.Write("Continue? (enter \"yes\" or \"no\"): ");
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
                    continue;
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
                needGo = false;
            }
            return true;
        }
    }
}
