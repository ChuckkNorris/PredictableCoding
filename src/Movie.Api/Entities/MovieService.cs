using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Movie.Api.Entities
{

    public class MovieService : IService
    {

        public IEnumerable<MovieDto> SearchMovies(string searchTerm)
        {
            IEnumerable<MovieDto> toReturn = new List<MovieDto>();
            string lowerSearchTerm = searchTerm?.ToLower();
            // Search Movies
            if (!String.IsNullOrEmpty(lowerSearchTerm))
            {
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

        public List<MovieDto> Movies = new List<MovieDto>() {
            new MovieDto {
                 Name = "Rush Hour",
                 Actors = new List<ActorDto>() {
                     new ActorDto { FirstName = "Chris", LastName = "Tucker" },
                     new ActorDto { LastName = "Chan" } // Missing first name (NULL)
                 }
            },
            new MovieDto {
                 Name = "Mr. Robot"
                 // MISSING ACTOR LIST (NULL)
            },
            new MovieDto {
                 Actors = new List<ActorDto>() {
                     new ActorDto { FirstName = "Edward", LastName = "Norton" },
                     new ActorDto { FirstName = "Brad", LastName = "Pitt" }
                 }
            },
             new MovieDto {
                 Name = "Step Brothers",
                 Actors = new List<ActorDto>()
            },
            null
        };

    }
   
    public class MovieDto
    {
        public string Name { get; set; }

        // Initialize your lists
        public IEnumerable<ActorDto> Actors { get; set; } // = new List<Actor>();

        public override string ToString()
        {
            string toReturn = $"'{this.Name}'";
            var actors = this.Actors?.Select(actor => actor.ToString());
            if (actors != null)
            {
                var actorNames = String.Join(", ", actors);
                toReturn = $" starring {actorNames}";
            }
            return toReturn;
        }
    }

    public class ActorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}
