using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PredictableCoding.Controllers.Entities;

namespace PredictableCoding.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }



    }
}
