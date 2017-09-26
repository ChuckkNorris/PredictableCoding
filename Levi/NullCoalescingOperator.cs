
using System;
using System.Collections.Generic;
using System.Linq;

namespace Levi
{
    public class NullCoalescingOperator
    {
        // Write your code to be expectant of null values
        public IEnumerable<Movie> SearchMovies(string searchTerm)
        {
            IEnumerable<Movie> toReturn;
            string lowerSearchTerm = searchTerm.ToLower();

            // Search Movies
            toReturn = this.Movies.Where(movie =>
                (movie.Name?.Contains(searchTerm) ?? false)
                || (movie.Actors?.Any(actor =>
                    (actor.FirstName?.ToLower().Contains(searchTerm) ?? false)
                    || (actor.LastName?.ToLower().Contains(searchTerm) ?? false)
                ) ?? false)
            );


            // toReturn = this.Movies.Where(movie => 
            //     (movie.Name != null && movie.Name.Contains(searchTerm))
            //     || (movie.Actors != null && movie.Actors.Any( actor =>
            //         actor.FirstName != null && actor.FirstName.ToLower().Contains(searchTerm)
            //         || actor.LastName != null && actor.LastName.ToLower().Contains(searchTerm)
            //     ))
            // );




            //     bool hasMovieName = movie.Name?.Contains(searchTerm);
            //     bool hasActorName = movie?.Actors != null && movie.Actors.Any(actor => 
            //         actor?.FirstName?.ToLower() == lowerSearchTerm
            //         || actor?.LastName?.ToLower() == lowerSearchTerm
            //     );
            //     return hasMovieName || hasActorName;
            // });

            // Retrieve Actor names from potentially incomplete data
            return toReturn;
        }


        public List<Movie> Movies = new List<Movie>() {
            new Movie {
                 Name = "Rush Hour",
                 Actors = new List<Actor>() {
                     new Actor { FirstName = "Chris", LastName = "Tucker" },
                     new Actor { LastName = "Chan" } // Missing first name (NULL)
                 }
            },
            new Movie {
                 Name = "Mr. Robot"
                 // MISSING ACTOR LIST (NULL)
            },
            new Movie {
                 Actors = new List<Actor>() {
                     new Actor { FirstName = "Edward", LastName = "Norton" },
                     new Actor { FirstName = "Brad", LastName = "Pitt" }
                 }
            },
             new Movie {
                 Name = "Step Brothers",
                 Actors = new List<Actor>()
            }
        };
    }

    public class Movie
    {
        public string Name { get; set; }

        public IEnumerable<Actor> Actors { get; set; } // = new List<Actor>();

        public override string ToString()
        {
            return $"'{this.Name}' starring {String.Join(", ", this.Actors?.Select(actor => actor.ToString()))}";
        }
    }

    public class Actor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}