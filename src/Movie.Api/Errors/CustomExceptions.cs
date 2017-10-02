using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Api.Errors
{

    public class UserFriendlyException : Exception
    {
        
        public UserFriendlyException(string message) : base(message)
        {

        }
    }

    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {

        }
    }

}
