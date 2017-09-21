using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PredictableCoding.Testing
{
    public class DBConnection
    {
        public DBConnection(string str);
        public void Connect();
        public Model Search() { return new Model(); }
    }
}
