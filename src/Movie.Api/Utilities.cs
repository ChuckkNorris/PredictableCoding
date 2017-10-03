using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Movie.Api
{
    public class ValidationUtil {
        public static bool IsValidEmail(string email) {
            bool toReturn = false;
            if (!String.IsNullOrEmpty(email)) {
                string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                + "@"
                + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
                Regex reg = new Regex(emailPattern);
                toReturn = reg.IsMatch(email);
            }
            return toReturn;
        }
    }


}
