using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamingIsHard_Code.Foundation
{
    public class Response
    {
        public List<int> Errors { get; set; }
        public List<string> Messages { get; set; } 
    }
}