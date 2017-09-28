using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PredictableCoding.Extensions;

namespace PredictableCoding.Controllers.Entities
{
    public class Movie {
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Actor> Actors { get; set; }

		private string _Genre;
        public string Genre {
			get => _Genre; 
			set => _Genre = value?.ToTitleCase();
		}
    }
}