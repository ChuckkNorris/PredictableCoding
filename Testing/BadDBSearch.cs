using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictableCoding.Testing
{
    public class BadDBSearch
    {
        //keyword = "azure" ; fieldToSearch = "name"
        public Model BadSearch(string connString, string keyword, string fieldToSearch)
        {
            var conn = new DBConnection(connString);
            conn.Connect();
            var result = conn.Search(keyword,fieldToSearch);
            return result;
        }
    }
}
