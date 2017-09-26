﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Levi
{
    class Program
    {
        static void Main(string[] args)
        {
            var nullCoalesce = new NullCoalescingOperator();
            var matchingMovies = nullCoalesce.SearchMovies(args?[0]);
            string formattedMovies = String.Join(", ", matchingMovies.Select(movie => movie.ToString()));
            Console.WriteLine($"{formattedMovies}");
        }
    }
}
