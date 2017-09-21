using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictableCoding.Testing
{
    public class BetterDBSearch
    {
        //keyword = "round" ; fieldToSearch = {"square" "round" "cylindrical"}
        public Model OKSearch(SearchRequest request)
        {
            var result = request.search();
            return result;
        }
        public DBConnection Connect(string connStr) {
            var ctx = new DBConnection(connStr);
            return ctx;
        }

        public bool ValidateParameters(SearchRequest request)
        {
            return request.isValid();
        }
    }
}
