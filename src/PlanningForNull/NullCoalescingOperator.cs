
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
            IEnumerable<Movie> toReturn = new List<Movie>();
            string lowerSearchTerm = searchTerm?.ToLower();

            // Search Movies
            if (!String.IsNullOrEmpty(lowerSearchTerm)) {
                toReturn = this.Movies?.Where(movie =>
                    (movie?.Name?.ToLower().Contains(searchTerm) ?? false)
                    || (movie?.Actors?.Any(actor =>
                        (actor?.FirstName?.ToLower().Contains(searchTerm) ?? false)
                        || (actor?.LastName?.ToLower().Contains(searchTerm) ?? false)
                    ) ?? false)
                );
            }
            else
                toReturn = this.Movies ?? toReturn;
            
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
            },
            null
        };
    }

    public class Movie
    {
        public string Name { get; set; }

        // Initialize your lists
        public IEnumerable<Actor> Actors { get; set; } // = new List<Actor>();

        public override string ToString()
        {
            string toReturn = $"'{this.Name}'";
            var actors = this.Actors?.Select(actor => actor.ToString());
            if (actors != null) {
                var actorNames = String.Join(", ", actors);
                toReturn = $" starring {actorNames}";
            }
            return toReturn;
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