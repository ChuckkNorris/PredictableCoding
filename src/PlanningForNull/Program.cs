using System;
using System.Collections.Generic;
using System.Linq;

namespace Levi
{
    class Program
    {
        static void Main(string[] args)
        {
            var nullCoalesce = new NullCoalescingOperator();
            var matchingMovies = nullCoalesce.SearchMovies(args?.FirstOrDefault());
            Console.WriteLine(matchingMovies);
            string formattedMovies = String.Join("\n", 
                matchingMovies.Select(movie => movie?.ToString()));
            Console.WriteLine($"{formattedMovies}");
        }
    }
}
