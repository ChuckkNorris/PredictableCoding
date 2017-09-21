using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictableCoding.Testing
{
    public class SearchRequest
    {
        public string keyword { get; set; }
        public string fieldToSearch { get; set; }
        public DBConnection ctx { get; set; }
        public Model search() { return ctx.Search(); }
        public bool isValid() { }
    }
}
