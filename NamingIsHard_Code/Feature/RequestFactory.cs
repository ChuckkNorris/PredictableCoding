using NamingIsHard_Code.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamingIsHard_Code.Feature
{
    public static class RequestFactory
    {
        public static Request Create_AddUserToList_Request(string email, string list)
        {
            return new Request { Email = email, List = list };
        }
    }
}